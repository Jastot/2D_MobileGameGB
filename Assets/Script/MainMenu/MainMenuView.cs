using Company.Project.Features.Shed;
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
            
        public void Init(UnityAction startGame,IShedController shedController)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonInventory.onClick.AddListener(shedController.Enter);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonInventory.onClick.RemoveAllListeners();
        }
    }
}

