using System;
using System.Collections.Generic;
using Company.Project.Features.Abilities;
using Company.Project.Features.Inventory;
using Company.Project.Features.Items;
using JetBrains.Annotations;
using UnityEngine;

namespace Company.Project.Features.Shed
{
    public class ShedController : BaseController, IShedController
    {
        private readonly IUpgradable _upgradable;
        
        private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
        private readonly IInventoryController _inventoryController;

        #region Life cycle
        
        public ShedController(
            [NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository,
            [NotNull] IInventoryController inventoryController,
            [NotNull] IUpgradable upgradable)
        {
            _upgradeHandlersRepository 
                = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));
            
            _inventoryController 
                =  inventoryController ?? throw new ArgumentNullException(nameof(inventoryController));;
            
            _upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));

            _inventoryController.Accept += AcceptModifications;
            _inventoryController.Exit += DeclineModifications;
            _inventoryController.HideInventory();
        }

        private void DeclineModifications(object sender, bool e)
        {
            Debug.Log("CloseWithoutSave");
            _inventoryController.HideInventory();
        }

        private void AcceptModifications(object sender, bool e)
        {
            Debug.Log("CloseWithSave");
            Exit();
            _inventoryController.HideInventory();
        }

        #endregion
        
        #region Methods
        
        private void UpgradeCarWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<IItem> equippedItems, 
            IReadOnlyList<IAbility> equippedAbilities,
            IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(upgradable);
                }
            }

            foreach (var ability in equippedAbilities)
            {
                upgradable.Abilities.Add(ability);
            }
        }

        #endregion
        
        #region IShedController

        public void Enter()
        {
            _inventoryController.ShowInventory();
        }
        
        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _upgradable, 
                _inventoryController.GetEquippedItems(),
                _inventoryController.GetEquippedAbilities(),
                _upgradeHandlersRepository.Collection);
        }

        #endregion
    }
}