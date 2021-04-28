using Company.Project.Features.Inventory;
using UnityEngine;

namespace Company.Project.Features.Abilities
{
    public class AbilityItemFactory: IItemFactory
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;

        public AbilityItemFactory(GameObject prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public GameObject CreateAnItem()
        {
            var gm = GameObject.Instantiate(_prefab, _parent, true);
            return gm;
        }
    }
}