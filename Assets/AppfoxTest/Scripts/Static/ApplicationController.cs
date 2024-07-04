using UnityEngine;

namespace AppFoxTest
{
    public static class ApplicationController
    {
        public static void SetPause(bool pause)
        {
            Time.timeScale = pause ? 0f : 1f;
        }
    }
}
