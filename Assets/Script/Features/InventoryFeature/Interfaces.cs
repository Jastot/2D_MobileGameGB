using System;
using System.Collections.Generic;
using Company.Project.Features.Abilities;
using Company.Project.Features.Items;
using Company.Project.UI;
using UnityEngine;

namespace Company.Project.Features.Inventory
{
    public interface IInventoryController : IAcceptOrDeclineView
    {
        IReadOnlyList<IItem> GetEquippedItems();
        IReadOnlyList<IAbility> GetEquippedAbilities();
        void ShowInventory();
        void HideInventory();
        
    }
    
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnequipItem(IItem item);
        IReadOnlyList<IAbility> GetEquippedAbilities();
        void EquipAbility(IAbility item);
        void UnequipAbility(IAbility item);
    }
    
    public interface IAcceptOrDeclineView
    {
        event EventHandler<bool> Exit;
        event EventHandler<bool> Accept;
        void ActivateButtons();
    }
    public interface IInventoryView : IView,IAcceptOrDeclineView
    {
        event EventHandler<IItem> SelectedItem;
        event EventHandler<IItem> DeselectedItem;
        event EventHandler<IAbility> SelectedAbility;
        event EventHandler<IAbility> DeselectedAbility;
        void Display(List<IItem> itemInfoCollection,List<IAbility> abilitiesInfoCollection);
    }

    public interface IItemFactory
    {
        GameObject CreateAnItem();
    }

    
}