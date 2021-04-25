using Company.Project.Content;
using JetBrains.Annotations;
using UnityEngine;

namespace Company.Project.Features.Abilities
{
    public class OilAbility: IAbility
    {
        [NotNull] private readonly AbilityItemConfig _config;

        public OilAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }
        public void Apply(IAbilityActivator activator)
        {
            var oilGun = Object.Instantiate(_config.view,new Vector3(-2.26900005f,0.782999992f,-0.122321412f),_config.view.transform.rotation);
        }
    }
}