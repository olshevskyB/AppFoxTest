using System;

namespace AppFoxTest
{
    public interface IUIFactory
    {
        public void CreateScreenAsync<T>(Action<T> callback) where T : AbstractScreenView;

        public void CreateStartScreen(Action<AbstractScreenView> callback);
    }
}
