using Company.Project.Features.Shed;
using Script.Rewards;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] 
        private Button _buttonStart;

        [SerializeField] 
        private Button _buttonInventory;
        [SerializeField] 
        private Button _buttonReward;
            
        public void Init(
            UnityAction startGame,
            IShedController shedController,
            InstallView installView)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonInventory.onClick.AddListener(shedController.Enter);
            _buttonReward.onClick.AddListener(installView.ShowRewards);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonInventory.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
        }
    }
}

