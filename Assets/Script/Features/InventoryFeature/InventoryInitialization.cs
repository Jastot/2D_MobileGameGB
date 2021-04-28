using System;
using System.Collections.Generic;
using Company.Project.Features.Abilities;
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
        private readonly EventHandler<IAbility> _selectedAbility;
        private readonly EventHandler<IAbility> _deselectedAbility;

        public InventoryInitialization(
            ResourcePath prefab,
            Transform parent,
            Transform parentAbility,
            List<IItem> _itemInfoCollection,
            List<IAbility> abilities,
            EventHandler<IItem> Selected,
            EventHandler<IItem> Deselected,
            EventHandler<IAbility> selectedAbility,
            EventHandler<IAbility> deselectedAbility)
        {
            _selected = Selected;
            _deselected = Deselected;
            _selectedAbility = selectedAbility;
            _deselectedAbility = deselectedAbility;
            InventoryItemFactory _factory = new InventoryItemFactory(
                ResourceLoader.LoadPrefab(prefab),
                parent
            );
            InventoryItemFactory _factoryAbility = new InventoryItemFactory(
                ResourceLoader.LoadPrefab(prefab),
                parentAbility
            );
            foreach (var item in _itemInfoCollection)
            {
                var itemGO = _factory.CreateAnItem();
                itemGO.GetComponentInChildren<Text>().text = item.Info.Title;
                var itemGOToggle = itemGO.GetComponent<Toggle>();
                itemGOToggle.onValueChanged.AddListener((bool arg)=>isToggleOnOrOffItem(item,itemGOToggle.isOn));
            }

            foreach (var ability in abilities)
            {
                var itemGO = _factoryAbility.CreateAnItem();
                Debug.Log(ability.GetConfig().Item.Info.Title);
                itemGO.GetComponentInChildren<Text>().text = ability.GetConfig().Item.Info.Title;
                var itemGOToggle = itemGO.GetComponent<Toggle>();
                itemGOToggle.onValueChanged.AddListener((bool arg)=>isToggleOnOrOffAbility(ability,itemGOToggle.isOn));
            }
            
        }

        public void isToggleOnOrOffItem(IItem item,bool isOn)
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

        public void isToggleOnOrOffAbility(IAbility ability, bool isOn)
        {
            if (isOn)
            {
                OnSelectedAbility(ability);
            }
            else
            {
                OnDeselectedAbility(ability);
            }
        }

        private void OnSelectedAbility(IAbility item)
        {
            _selectedAbility?.Invoke(this, item);
        }

        private void OnDeselectedAbility(IAbility item)
        {
            _deselectedAbility?.Invoke(this, item);
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