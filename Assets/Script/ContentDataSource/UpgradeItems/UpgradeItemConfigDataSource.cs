using UnityEngine;

namespace Company.Project.Content
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource", order = 0)]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        public UpgradeItemConfig[] itemConfigs;
    }
}