using Company.Project.Features.Items;
using UnityEngine;

namespace Company.Project.Content
{
    [CreateAssetMenu(fileName = "Ability item", menuName = "Ability item", order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public GameObject view;
        public AbilityType type;
        public float value;
        public Item Item;
        public void SetItem()
        {
            Item = new Item
            {
                Id = itemConfig.id,
                Info = new ItemInfo {Title = itemConfig.title}
            }; 
        }
        public int Id => itemConfig.id;
    }
    
    
    
    
    
    public enum AbilityType
    {
        None,
        Gun,
        Oil,
        Jump,
    }
}