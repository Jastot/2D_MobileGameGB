using Company.Project.Content;
using JetBrains.Annotations;

namespace Company.Project.Features.Abilities
{
    public class NitroAbility: IAbility
    {
        [NotNull] private readonly AbilityItemConfig _config;

        public NitroAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }
        public void Apply(IAbilityActivator activator)
        {
            //activator.GetViewObject().
        }
    }
}