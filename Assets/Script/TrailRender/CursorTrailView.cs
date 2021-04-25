using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Trail
{
    [RequireComponent(typeof(TrailRenderer))]
    public class CursorTrailView : MonoBehaviour
    {
        private bool _isInit;
        private Camera _camera;
        private TrailRenderer _trailRenderer;

        private void Start()
        {
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        public void Init()
        {
            _camera = Camera.main;
            _isInit = _camera != null;
        }

        private void Update()
        {
            if (_isInit)
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                transform.position = mousePosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _trailRenderer.Clear();
            }
        }
    }
}

