using System.Collections.Generic;
using Company.Project.Content;
using Company.Project.Features.Abilities;
using Company.Project.Features.Shed;

namespace Profile
{
    public class Car : IUpgradable
    {
        #region Properties
      
        public float Speed { get; set; }
        public List<IAbility> Abilities { get; set; }

        #endregion
        
        #region Fields
      
        private readonly float _defaultSpeed;
        
        #endregion

        
        #region Life cycle
    
        public Car(float speed)
        {
            // ну можно в PlayerPrefs записать строку с скоростью и списком абилок...
            // но опять же гараж оторван от машины,что неправильно. но можно и из гаража сохранить...
            _defaultSpeed = speed;
            Abilities = new List<IAbility>();
            Restore();
        }

        #endregion

        #region IUpgradable

        public void Restore()
        {
            Speed = _defaultSpeed;
        }

        #endregion
    }
}

