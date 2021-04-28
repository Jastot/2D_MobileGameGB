using System.Collections;
using Company.Project.Content;
using JetBrains.Annotations;
using Script.Coroutine;
using Tools;
using UnityEngine;
using Water2D;

namespace Company.Project.Features.Abilities
{
    public class OilAbility: IAbility
    {
        [NotNull] private readonly AbilityItemConfig _config;
        

        public OilAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }

        public AbilityItemConfig GetConfig()
        {
            return _config;
        }

        public void Apply(IAbilityActivator activator)
        {
            // var oil = Object.Instantiate(ResourceLoader.LoadPrefab(new ResourcePath{PathResource = "Prefabs/OilDrop"}));
            // var oilGun = Object.Instantiate(_config.view,
            //     activator.GetViewObject().transform.position + new Vector3(-2.26900005f,0.782999992f,-0.122321412f),
            //     _config.view.transform.rotation,
            //     activator.GetViewObject().transform);
            //
            // OilGunLiveTimer(oilGun,oil).StartCoroutine(out _);
        }

        private IEnumerator OilGunLiveTimer(GameObject gameObject,GameObject oil)
        {
            yield return new WaitForSeconds(10);
            Object.Destroy(gameObject);
            Object.Destroy(oil);
        }
    }
}