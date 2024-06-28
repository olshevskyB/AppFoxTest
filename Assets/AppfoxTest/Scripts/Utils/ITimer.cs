using System;

namespace AppFoxTest
{
    public interface ITimer
    {
        public bool this[object running] { get; }

        public void StartTimer(Action onEnd, float time, object invoker);

        public void StartTimer(Action onEnd, Action<float, float> onUpdate, float time, object invoker);
    }
}
