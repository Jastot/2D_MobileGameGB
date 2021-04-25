using System;
using System.Collections.Generic;
using Company.Project.Features.Items;
using Company.Project.UI;
using UnityEngine;

namespace Company.Project.Features.Inventory
{
    public interface IInventoryController : IAcceptOrDeclineView
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void ShowInventory(Action hideAction);
        void HideInventory();
        
    }
    
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnequipItem(IItem item);
    }
    
    public interface IAcceptOrDeclineView
    {
        event EventHandler<bool> Exit;
        event EventHandler<bool> Accept;
        void ActivateButtons();
    }
    public interface IInventoryView : IView,IAcceptOrDeclineView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> itemInfoCollection);
    }

    public interface IItemFactory
    {
        GameObject CreateAnItem();
    }

    
}