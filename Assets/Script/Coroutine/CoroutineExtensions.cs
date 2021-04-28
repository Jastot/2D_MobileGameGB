using System.Collections;
using UnityEngine;

namespace Script.Coroutine
{
    public static class CoroutineExtensions
    {
        private static AsyncOperationBehavior _asyncOperationBehavior = null;
        
        public static UnityEngine.Coroutine StartCoroutine(this IEnumerator task, out CoroutineController coroutineController)
        {
            Initialize();
            if (task == null)
            {
                throw new System.ArgumentNullException(nameof(task));
            }
            
            coroutineController = new CoroutineController(task);
            return _asyncOperationBehavior.StartCoroutine(coroutineController.Start());
        }

        public static void StopCoroutine(this IEnumerator task,
            out CoroutineController coroutineController)
        {
            Initialize();
            if (task == null)
            {
                throw new System.ArgumentNullException(nameof(task));
            }

            coroutineController = new CoroutineController(task);
            _asyncOperationBehavior.StopAllCoroutines();
        } 

        public static void Initialize()
        {
            if (_asyncOperationBehavior != null)
            {
                return;
            }

            GameObject go = new GameObject();
            Object.DontDestroyOnLoad(go);
            go.name = "AsyncOperationExtensionCoroutine";
            go.hideFlags = HideFlags.HideAndDontSave;

            _asyncOperationBehavior = go.AddComponent<AsyncOperationBehavior>();
        }
    }
}