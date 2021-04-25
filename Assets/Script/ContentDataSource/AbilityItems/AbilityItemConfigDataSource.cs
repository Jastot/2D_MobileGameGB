using UnityEngine;

namespace Company.Project.Content
{
    [CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "AbilityItemConfigDataSource", order = 0)]
    public class AbilityItemConfigDataSource : ScriptableObject
    {
        public AbilityItemConfig[] itemConfigs;
    }
}