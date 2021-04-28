using Company.Project.Content;

namespace Company.Project.Features.Abilities
{
    public class StubAbility : IAbility
    {
        public static readonly IAbility Default = new StubAbility();

        #region IAbility

        public AbilityItemConfig GetConfig()
        {
            return null;
        }

        public void Apply(IAbilityActivator activator)
        {
        }
        
        #endregion
    }
}