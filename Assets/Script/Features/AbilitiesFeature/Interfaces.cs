using System;
using System.Collections.Generic;
using Company.Project.Content;
using Company.Project.Features.Items;
using Company.Project.UI;
using Profile;
using UnityEngine;

namespace Company.Project.Features.Abilities
{
    public interface IAbility
    {
        AbilityItemConfig GetConfig();
        void Apply(IAbilityActivator activator);
    }

    public interface IAbilityActivator
    {
        GameObject GetViewObject();
        Car GetCarParameters();
    }
    
    public interface IAbilityCollectionView : IView
    {
        event EventHandler<IAbility> UseRequested;
        void Display(IReadOnlyList<IAbility> abilityItems);
    }
    
    public interface IAbilitiesController
    {
        void ShowAbilities();
    }
}