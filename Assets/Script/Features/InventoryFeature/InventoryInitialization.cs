using System;
using System.Collections.Generic;
using Company.Project.Features.Items;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Company.Project.Features.Inventory
{
    public class InventoryInitialization
    {
        private readonly EventHandler<IItem> _selected;
        private readonly EventHandler<IItem> _deselected;

        public InventoryInitialization(
            ResourcePath prefab,
            Transform parent,
            List<IItem> _itemInfoCollection,
            EventHandler<IItem> Selected,
            EventHandler<IItem> Deselected)
        {
            _selected = Selected;
            _deselected = Deselected;
            InventoryItemFactory _factory = new InventoryItemFactory(
                ResourceLoader.LoadPrefab(prefab),
                parent
            );
            foreach (var item in _itemInfoCollection)
            {
                var itemGO = _factory.CreateAnItem();
                itemGO.GetComponentInChildren<Text>().text = item.Info.Title;
                var itemGOToggle = itemGO.GetComponent<Toggle>();
                itemGOToggle.onValueChanged.AddListener((bool arg)=>isToggleOnOrOff(item,itemGOToggle.isOn));
            }
        }

        public void isToggleOnOrOff(IItem item,bool isOn)
        {
            if (isOn)
            {
                OnSelected(item);
            }
            else
            {
                OnDeselected(item);
            }
        }
        
        protected virtual void OnSelected(IItem e)
        {
            _selected?.Invoke(this, e);
        }

        protected virtual void OnDeselected(IItem e)
        {
            _deselected?.Invoke(this, e);
        }
        
    }
}