using System.Threading;

namespace PopupBackgroundApp.Utils
{
    public static class SingleInstance
    {
        private static Mutex _mutex;

        public static bool Start()
        {
            _mutex = new Mutex(true, "PopupBackgroundAppMutex", out bool created);
            return created;
        }
    }
}
