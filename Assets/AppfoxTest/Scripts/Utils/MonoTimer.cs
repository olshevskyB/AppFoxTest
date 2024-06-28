using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppFoxTest
{
    public class MonoTimer : MonoBehaviour, ITimer
    {
        private Dictionary<object, bool> _runningTimers = new Dictionary<object, bool>();

        public bool this[object running]
        {
            get
            {
                if (_runningTimers.TryGetValue(running, out bool value))
                {
                    return value;
                }
                return false;
            }
        }

        public void StartTimer(Action onEnd, float time, object invoker)
        {
            StartCoroutine(StartTimerCoroutine(onEnd, time, invoker));
        }

        public void StartTimer(Action onEnd, Action<float, float> onUpdate, float time, object invoker)
        {
            StartCoroutine(StartTimerCoroutine(onEnd, time, invoker, onUpdate));
        }

        private IEnumerator StartTimerCoroutine(Action onEnd, float time, object invoker, Action<float, float> onUpdate = null)
        {
            float starTime = 0f;
            _runningTimers[invoker] = true;
            while (starTime < time)
            {
                starTime += Time.deltaTime;
                onUpdate?.Invoke(starTime, starTime / time);
                yield return null;
            }
            onEnd.Invoke();
            _runningTimers[invoker] = false;
        }
    }
}
