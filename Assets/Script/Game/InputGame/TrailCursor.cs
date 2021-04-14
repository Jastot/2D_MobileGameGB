using JoostenProductions;
using Tools;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.InputLogic
{
    internal sealed  class TrailCursor: BaseInputView, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private float _threshold = 40;
        private Vector2 _startPosition;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private GameObject _trail;
        private Camera _camera;
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            _camera = Camera.main;
        }
        public void OnDrag(PointerEventData eventData)
        {
            float diff = eventData.position.x - _startPosition.x;
            if (Mathf.Abs(diff) >= _threshold)
            {
                if(diff > 0)
                    OnRightMove(_speed * Time.deltaTime);
                else
                    OnLeftMove(-_speed * Time.deltaTime);
            }

            var trailX = eventData.position.x / _camera.pixelWidth;
            var trailY = eventData.position.y / _camera.pixelHeight;
            _trail.transform.position = new Vector3(trailX, trailY, 0);
            Debug.Log(trailX);
            Debug.Log(trailY);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
            _trailRenderer.emitting = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _trailRenderer.emitting = false;
        }
    }
}