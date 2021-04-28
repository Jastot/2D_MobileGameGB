using System;
using System.Collections.Generic;
using Company.Project.Features.Items;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Company.Project.Features.Abilities
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        #region Fields
        
        [SerializeField] private GameObject _contextWhereToSetItem;
        [SerializeField] private GameObject _abilitySet;
        private IReadOnlyList<IAbility> _abilityItems;

        private ResourcePath prefab
            = new ResourcePath {PathResource = "Prefabs/Ability"};
        #endregion

        #region Methods
        
        /*protected virtual void OnUseRequested(IItem e)
        {
            UseRequested?.Invoke(this, e);
        }*/

        #endregion

        #region IAbilityCollectionView

        public event EventHandler<IAbility> UseRequested;
        
        public void Display(IReadOnlyList<IAbility> abilityItems)
        {
            _abilityItems = abilityItems;
            AbilitiesInitialization abilitiesInitialization =
                new AbilitiesInitialization(
                    prefab,
                    _contextWhereToSetItem.transform,
                    _abilityItems,
                    UseRequested
                    );
        }

        public void Show()
        {
            _abilitySet.SetActive(true);
        }

        public void Hide()
        {
            Destroy(_contextWhereToSetItem.GetComponentInChildren<Button>().gameObject);
            _abilitySet.SetActive(false);
        }

        #endregion
    }
}