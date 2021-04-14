using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Game.InputLogic
{
    internal sealed class InputTapView : BaseInputView
    {
        private int idR;
        private int idL;
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            idR = _buttonMoveRight.GetInstanceID();
            idL = _buttonMoveLeft.GetInstanceID();
            _buttonMoveRight.onClick.AddListener(()=>OnClick(_buttonMoveRight.GetInstanceID()));
            _buttonMoveLeft.onClick.AddListener(()=>OnClick(_buttonMoveLeft.GetInstanceID()));
        }

        [SerializeField] 
        private Button _buttonMoveRight;
        [SerializeField] 
        private Button _buttonMoveLeft;

        private void OnClick(int id)
        {
            if(id == idR)
                OnRightMove(Time.deltaTime * _speed);
            if(id == idL)
                OnLeftMove(Time.deltaTime *_speed);
        }
    }
}

