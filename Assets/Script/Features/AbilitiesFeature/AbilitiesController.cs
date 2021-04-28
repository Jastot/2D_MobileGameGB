using System;
using Company.Project.Features.Inventory;
using Company.Project.Features.Items;
using JetBrains.Annotations;

namespace Company.Project.Features.Abilities
{
    public class AbilitiesController : BaseController, IAbilitiesController
    {
        #region Fields

        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _carController;
        
        #endregion

        #region Life cycle
        
        public AbilitiesController(
            [NotNull] IAbilityCollectionView abilityCollectionView,
            [NotNull] IAbilityActivator abilityActivator)
        {

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

        private void OnAbilityUseRequested(object sender, IAbility e)
        {
            // if (_abilityRepository.Collection.TryGetValue(e.GetConfig().Id, out var ability))
            // {
            //     ability.Apply(_carController);
            // }
            e.Apply(_carController);
        }

        #endregion

        #region IAbilityController

        public void ShowAbilities()
        {
            _abilityCollectionView.Show();
            _abilityCollectionView.Display(_carController.GetCarParameters().Abilities);
        }

        #endregion
    }
}