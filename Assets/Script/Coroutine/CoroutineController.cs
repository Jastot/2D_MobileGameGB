using System.Collections;

namespace Script.Coroutine
{
    public sealed class CoroutineController
    {
        private IEnumerator _routine;

        public CoroutineState state;
        public CoroutineController(IEnumerator routine)
        {
            _routine = routine;
            state = CoroutineState.Ready;
        }
        public IEnumerator Start()
        {
            if (state != CoroutineState.Ready)
            {
                throw new System.InvalidOperationException("Unable to start coroutine in state: " + state);
            }

            state = CoroutineState.Running;
            while (_routine.MoveNext())
            {
                yield return _routine.Current;

                if (state == CoroutineState.Finished)
                {
                    yield break;
                }
            }

            state = CoroutineState.Finished;
        }

        public void Stop()
        {
            if (state != CoroutineState.Running)
            {
                throw new System.InvalidOperationException("Unable to stop coroutine in state: " + state);
            }

            state = CoroutineState.Finished;
        }
    }
}