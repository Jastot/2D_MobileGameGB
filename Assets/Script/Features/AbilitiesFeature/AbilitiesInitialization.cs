using System;
using System.Collections.Generic;
using Company.Project.Features.Items;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Company.Project.Features.Abilities
{
    public sealed class AbilitiesInitialization
    {
        private readonly EventHandler<IAbility> _useRequested;

        public AbilitiesInitialization(
            ResourcePath prefab,
            Transform parent,
            IReadOnlyList<IAbility> items,
            EventHandler<IAbility> useRequested
            )
        {
            _useRequested = useRequested;
            AbilityItemFactory _factory = new AbilityItemFactory(
                ResourceLoader.LoadPrefab(prefab),
                parent
            );
            foreach (var item in items)
            {
                var itemGO = _factory.CreateAnItem();
                itemGO.GetComponentInChildren<Text>().text = 
                    item.GetConfig().Item.Info.Title;
                var itemGOToggle = itemGO.GetComponent<Button>();
                itemGOToggle.onClick.AddListener(()=>CastAbility(item));
            }
        }

        private void CastAbility(IAbility item)
        {
            _useRequested?.Invoke(this,item);
        }
    }
}