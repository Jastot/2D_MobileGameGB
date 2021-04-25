using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IInventoryView _inventoryView;
        private Action _hideAction;

        
        #endregion

        #region Life cycle
        
        public InventoryController(
            [NotNull] IRepository<int, IItem> itemsRepository,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IInventoryView inventoryView)
        {
            _itemsRepository 
                = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            
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

        public void ShowInventory(Action hideAction)
        {
            _hideAction = hideAction;
            _inventoryView.Show();
            _inventoryView.Display(_itemsRepository.Collection.Values.ToList());
        }

        public void HideInventory()
        {
            _inventoryView.Hide();
            _hideAction?.Invoke();
        }

        #endregion
        
        #region Methods
        
        private void SetupView(IInventoryView inventoryView)
        {
            // здесь могут быть дополнительные настройки
            inventoryView.Selected += OnItemSelected;
            inventoryView.Deselected += OnItemDeselected;
            inventoryView.Accept += AcceptAllModifications;
            inventoryView.Exit += ExitWithoutModifications;
        }

        private void CleanupView()
        {
            // здесь могут быть дополнительные зачистки
            _inventoryView.Selected -= OnItemSelected;
            _inventoryView.Deselected -= OnItemDeselected;
            _inventoryView.Accept -= AcceptAllModifications;
        }

        private void AcceptAllModifications(object sender, bool e)
        {
            Accept?.Invoke(sender,e);
        }
        
        private void ExitWithoutModifications(object sender, bool e)
        {
            Exit?.Invoke(sender,e);
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