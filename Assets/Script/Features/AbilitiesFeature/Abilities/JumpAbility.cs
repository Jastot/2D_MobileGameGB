using Company.Project.Content;
using JetBrains.Annotations;
using UnityEngine;

namespace Company.Project.Features.Abilities
{
    public class JumpAbility: IAbility
    {
        #region Fields

        private AbilityItemConfig _config;

        #endregion

        #region Life cycle

        public JumpAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }

        #endregion

        #region IAbility

        public AbilityItemConfig GetConfig()
        {
            return _config;
        }

        public void Apply(IAbilityActivator activator)
        {
            activator.GetViewObject().GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5),ForceMode2D.Impulse);
            foreach (var child in activator.GetViewObject().GetComponentsInChildren<Rigidbody2D>())
            {
                child.AddForce(new Vector2(0,5),ForceMode2D.Impulse);
            }
        }

        #endregion
    }
}