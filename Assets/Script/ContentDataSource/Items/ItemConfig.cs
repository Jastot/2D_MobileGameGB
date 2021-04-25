using UnityEngine;

namespace Company.Project.Content
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public int id;
        public string title;
    }
}