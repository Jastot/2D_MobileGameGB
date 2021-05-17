using TMPro;
using UnityEngine;

namespace Script.Rewards
{
    public class CurrencyView: MonoBehaviour
    {
        private const string TonneKey = nameof(TonneKey);
        private const string WheelKey = nameof(WheelKey);
    
        public static CurrencyView Instance;

        [SerializeField] private TMP_Text _currentCountWheels;

        [SerializeField] private TMP_Text _currentCountTonnes;

        private int Wheels
        {
            get => PlayerPrefs.GetInt(TonneKey, 0);
            set => PlayerPrefs.SetInt(TonneKey, value);
        }

        private int Tonnes
        {
            get => PlayerPrefs.GetInt(WheelKey, 0);
            set => PlayerPrefs.SetInt(WheelKey, value);
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            RefreshText();
        }

        public void AddTonne(int value)
        {
            Tonnes += value;

            RefreshText();
        }
    
        public void AddWheels(int value)
        {
            Wheels += value;
        
            RefreshText();
        }

        private void RefreshText()
        {
            _currentCountWheels.text = Tonnes.ToString();
            _currentCountTonnes.text = Wheels.ToString();
        }
    }
}