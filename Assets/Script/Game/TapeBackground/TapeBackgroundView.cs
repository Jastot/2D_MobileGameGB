using Tools;
using UnityEngine;

namespace Game.TapeBackground
{
    public class TapeBackgroundView : MonoBehaviour
    {
        [SerializeField] 
        private Background[] _backgrounds;

        private IReadOnlySubscriptionProperty<float> _diff;

        public void Init(IReadOnlySubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }

        protected void OnDestroy()
        {
            _diff?.SubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (Background background in _backgrounds)
            {
                background.Move(-value);
            }
        }
    }
}

