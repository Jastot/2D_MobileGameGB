using System;
using System.Collections.Generic;
using System.Linq;
using Company.Project.Features.Abilities;
using Company.Project.Features.Items;
using JetBrains.Annotations;
using UnityEngine;

namespace Company.Project.Features.Inventory
{
    public class InventoryController : BaseController, IInventoryController
    {
        #region Fields
        
        private readonly IRepository<int, IItem> _itemsRepository;
        private readonly IInventoryModel _inventoryModel;
        private readonly IRepository<int, IAbility> _abilityRepository;
        private readonly IInventoryView _inventoryView;


        #endregion

        #region Life cycle
        
        public InventoryController(
            [NotNull] IRepository<int, IItem> itemsRepository,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IRepository<int, IAbility> abilityRepository,
            [NotNull] IInventoryView inventoryView)
        {
            _itemsRepository 
                = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _abilityRepository 
                = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));

            _inventoryModel 
                = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));

            _inventoryView
                = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
            _inventoryView.ActivateButtons();
            SetupView(_inventoryView);
        }
        
        protected override void OnDispose()
        {
            CleanupView();
            base.OnDispose();
        }

        #endregion

        #region IInventoryController

        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _inventoryModel.GetEquippedItems();
        }

        public IReadOnlyList<IAbility> GetEquippedAbilities()
        {
            return _inventoryModel.GetEquippedAbilities();
        }

        public void ShowInventory()
        {
            _inventoryView.Show();
            _inventoryView.Display(
                _itemsRepository.Collection.Values.ToList(),
                _abilityRepository.Collection.Values.ToList()
                );
        }

        public void HideInventory()
        {
            _inventoryView.Hide();
        }

        #endregion
        
        #region Methods
        
        private void SetupView(IInventoryView inventoryView)
        {
            // здесь могут быть дополнительные настройки
            inventoryView.SelectedItem += OnItemSelected;
            inventoryView.DeselectedItem += OnItemDeselected;
            inventoryView.SelectedAbility += OnAbilitySelected;
            inventoryView.DeselectedAbility += OnAbilityDeselected;
            inventoryView.Accept += AcceptAllModifications;
            inventoryView.Exit += ExitWithoutModifications;
        }

        private void CleanupView()
        {
            // здесь могут быть дополнительные зачистки
            _inventoryView.SelectedItem -= OnItemSelected;
            _inventoryView.DeselectedItem -= OnItemDeselected;
            _inventoryView.SelectedAbility -= OnAbilitySelected;
            _inventoryView.DeselectedAbility -= OnAbilityDeselected;
            _inventoryView.Accept -= AcceptAllModifications;
            _inventoryView.Exit -= ExitWithoutModifications;
        }

        private void AcceptAllModifications(object sender, bool e)
        {
            Accept?.Invoke(sender,e);
        }
        
        private void ExitWithoutModifications(object sender, bool e)
        {
            Exit?.Invoke(sender,e);
        }
        
        private void OnAbilitySelected(object sender, IAbility item)
        {
            _inventoryModel.EquipAbility(item);
        }
        
        private void OnAbilityDeselected(object sender, IAbility item)
        {
            _inventoryModel.EquipAbility(item);
        }
        
        private void OnItemSelected(object sender, IItem item)
        {
            _inventoryModel.EquipItem(item);
        }
        
        private void OnItemDeselected(object sender, IItem item)
        {
            _inventoryModel.UnequipItem(item);
        }
        
        #endregion

        public event EventHandler<bool> Exit;
        public event EventHandler<bool> Accept;
        public void ActivateButtons() { }
    }
}