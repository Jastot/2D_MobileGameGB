using Company.Project.ContentData;
using Company.Project.Features.Abilities;
using Company.Project.Features.Inventory;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    public class GameController : BaseController
    {
        #region Life cycle
        
        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var tapeBackgroundController =
                new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
            var inputGameController =
                new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            var carController = new CarController(profilePlayer.CurrentCar);
            AddController(carController);
            
            // можно внедрить как зависимость для другого контроллера
            var abilityController = ConfigureAbilityController(placeForUi, carController);
        }

        #endregion

        #region Methods

        private IAbilitiesController ConfigureAbilityController(
            Transform placeForUi,
            IAbilityActivator abilityActivator)
        {
            
            //var abilityItemsConfigCollection 
            //    = ContentDataSourceLoader.LoadAbilityItemConfigs(new ResourcePath {PathResource = "DataSource/Ability/AbilityItemConfigDataSource"});
            // var abilityRepository 
            //     = new AbilityRepository(abilityItemsConfigCollection);
            var abilityCollectionViewPath 
                = new ResourcePath {PathResource = $"Prefabs/{nameof(AbilityCollectionView)}"};
            var abilityCollectionView 
                = ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(abilityCollectionViewPath, placeForUi, false);
            AddGameObjects(abilityCollectionView.gameObject);
            
            // загрузить в модель экипированные предметы можно любым способом
            var inventoryModel = new InventoryModel();
            var abilitiesController = new AbilitiesController(
                abilityCollectionView,
                abilityActivator);
            
            AddController(abilitiesController);
            abilitiesController.ShowAbilities();
            return abilitiesController;
        }

        #endregion
    }
}

