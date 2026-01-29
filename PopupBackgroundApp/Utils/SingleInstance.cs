using System.Threading;

namespace PopupBackgroundApp.Utils
{
    public static class SingleInstance
    {
        private static Mutex _mutex;

        public static bool Start()
        {
            bool createdNew;
            _mutex = new Mutex(true, "PopupBackgroundAppMutex", out createdNew);
            return createdNew;
        }
    }
}
