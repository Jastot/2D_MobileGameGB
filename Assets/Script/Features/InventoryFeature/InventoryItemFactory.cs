using UnityEngine;

namespace Company.Project.Features.Inventory
{
    public class InventoryItemFactory: IItemFactory
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;

        public InventoryItemFactory(GameObject prefab, Transform parent)
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