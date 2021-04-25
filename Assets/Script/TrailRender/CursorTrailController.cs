using Tools;
using UnityEngine;

namespace Game.Trail
{
    public class CursorTrailController : BaseController
    {
        public CursorTrailController()
        {
            _view = LoadView();
            _view.Init();
        }
        
        
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/trailCursor"};
        private CursorTrailView _view;

        private CursorTrailView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CursorTrailView>();
        } 
    }
}

