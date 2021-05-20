﻿using UnityEngine;

namespace Script.IIOponent
{
    interface IEnemy
    {
        void Update(DataPlayer dataPlayer, DataType dataType);
    }

    class Enemy : IEnemy
    {
        private const int KCoins = 5;
        private const float KPower = 1.5f;
        private const int MaxHealthPlayer = 20;
  
        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;

        public Enemy(string name)
        {
            _name = name;
        }

        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _moneyPlayer = dataPlayer.Money;
                    break;
          
                case DataType.Health:
                    _healthPlayer = dataPlayer.Health;
                    break;
          
                case DataType.Power:
                    _powerPlayer = dataPlayer.Power;
                    break;
            }
      
            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }

        public int Power
        {
            get
            {
                // изменить формулу....хм.
                var kHealth = _healthPlayer > MaxHealthPlayer ? 100 : 5;
                var power = (int) (_moneyPlayer / KCoins + kHealth + _powerPlayer / KPower);
          
                return power;
            }
        }
    }

}