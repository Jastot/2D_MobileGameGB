using System;
using System.Collections.Generic;
using Company.Project.Features.Abilities;
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
        [SerializeField] private GameObject _contextWhereToSetItemAbility;
        [SerializeField] private GameObject _inventory;
        private List<IItem> _itemInfoCollection;
        private List<IAbility> _abilitiesInfoCollection;
        
        private ResourcePath prefab
            = new ResourcePath {PathResource = "Prefabs/Item"};
        
        
        
        #endregion

        #region IInventoryView
        
        public event EventHandler<IItem> SelectedItem;
        public event EventHandler<IItem> DeselectedItem;
        
        public event EventHandler<IAbility> SelectedAbility;
        public event EventHandler<IAbility> DeselectedAbility;
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
            foreach (var toggle in _contextWhereToSetItem.GetComponentsInChildren<Toggle>())
            {
                Destroy(toggle.gameObject);
            }
            _inventory.SetActive(false);
        }

        public void Display(
            List<IItem> itemInfoCollection,
            List<IAbility> abilitiesInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;
            _abilitiesInfoCollection = abilitiesInfoCollection;
            InventoryInitialization inventoryInitialization = 
                new InventoryInitialization(
                    prefab,
                    _contextWhereToSetItem.transform,
                    _contextWhereToSetItemAbility.transform,
                    _itemInfoCollection,
                    _abilitiesInfoCollection,
                    SelectedItem,
                    DeselectedItem,
                    SelectedAbility,
                    DeselectedAbility
                    );
        
        }
        #endregion
    }
}