using System;
using Company.Project.Features.Inventory;
using Company.Project.Features.Items;
using JetBrains.Annotations;

namespace Company.Project.Features.Abilities
{
    public class AbilitiesController : BaseController, IAbilitiesController
    {
        #region Fields

        private readonly IRepository<int, IAbility> _abilityRepository;
        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _carController;
        
        #endregion

        #region Life cycle
        
        public AbilitiesController(
            [NotNull] IRepository<int, IAbility> abilityRepository,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IAbilityCollectionView abilityCollectionView,
            [NotNull] IAbilityActivator abilityActivator)
        {
            _abilityRepository
                = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));

            _inventoryModel
                = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));

            _abilityCollectionView
                = abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView)); 
            
            _carController
                = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
           
            SetupView(_abilityCollectionView);
        }

        protected override void OnDispose()
        {
            CleanupView(_abilityCollectionView);
            base.OnDispose();
        }

        #endregion

        #region Methods

        private void SetupView(IAbilityCollectionView view)
        {
            // здесь могут быть дополнительные настройки
            view.UseRequested += OnAbilityUseRequested;
        }
        
        private void CleanupView(IAbilityCollectionView view)
        {
            // здесь могут быть дополнительные зачистки
            view.UseRequested -= OnAbilityUseRequested;
        }

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.Collection.TryGetValue(e.Id, out var ability))
            {
                ability.Apply(_carController);
            }
        }

        #endregion

        #region IAbilityController

        public void ShowAbilities()
        {
            _abilityCollectionView.Show();
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        }

        #endregion
    }
}