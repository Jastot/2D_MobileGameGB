using System;
using System.Collections.Generic;
using Company.Project.Features.Items;
using Tools;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Company.Project.Features.Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        #region Fields

        [SerializeField] private Button _cancel;
        [SerializeField] private Button _accept;
        [SerializeField] private GameObject _contextWhereToSetItem;
        [SerializeField] private GameObject _inventory;
        private List<IItem> _itemInfoCollection;
        
        private ResourcePath prefab
            = new ResourcePath {PathResource = "Prefabs/Item"};
        
        
        
        #endregion

        #region IInventoryView
        
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;
        public event EventHandler<bool> Exit;
        public event EventHandler<bool> Accept;

        public void ActivateButtons()
        {
            _accept.onClick.AddListener(()=>AcceptAll());
            _cancel.onClick.AddListener(()=>DeclineAll());
        }

        private void DeclineAll()
        {
            Exit?.Invoke(_cancel,true);
        }

        private void AcceptAll()
        {
            Accept?.Invoke(_accept,true);
        }

        public void Show()
        {
            _inventory.SetActive(true);
        }
        
        public void Hide()
        {
            Destroy(_contextWhereToSetItem.GetComponentInChildren<Toggle>().gameObject);
            _inventory.SetActive(false);
        }

        public void Display(List<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;
            InventoryInitialization inventoryInitialization = 
                new InventoryInitialization(
                    prefab,
                    _contextWhereToSetItem.transform,
                    _itemInfoCollection,
                    Selected,
                    Deselected
                    );
        }
        #endregion
    }
}