using System.Collections.Generic;
using Company.Project.Content;
using Company.Project.Features.Abilities;

namespace Company.Project.Features.Shed
{
    public interface IShedController
    {
        void Enter();
        void Exit();
    }
    
    public interface IUpgradeHandler
    {
        IUpgradable Upgrade(IUpgradable upgradable);
    }

    public interface IUpgradable
    {
        void Restore();
        float Speed { get; set; }
        
        List<IAbility> Abilities { get; set; } 
    }
}