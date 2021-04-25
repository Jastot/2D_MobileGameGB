using Tools;
using Company.Project.Features.Abilities;
using Profile;
using UnityEngine;

namespace Game
{
    public class CarController : BaseController, IAbilityActivator
    {
        private readonly Car _car;

        #region Fields

        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};
        private readonly CarView _carView;

        #endregion
        
        #region Life cycle
        
        public CarController(Car car)
        {
            _car = car;
            _carView = LoadView();
        }
        
        #endregion

        #region Methods
        
        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }

        #endregion

        #region IAbilityActivator
        
        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }

        public Car GetCarParameters()
        {
            return _car;
        }
        #endregion
    } 
}

