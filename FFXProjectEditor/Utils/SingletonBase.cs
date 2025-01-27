using CommunityToolkit.Mvvm.ComponentModel;

namespace FFXProjectEditor.Utils
{
    public class SingletonBase<T> : ObservableObject where T : class, new()
    {
        private static T _instance;
        private static readonly object _lock = new object();

        // Protected constructor to prevent instantiation outside of the class
        protected SingletonBase() { }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock) // Ensure thread-safety
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }

        public static void Restart()
        {
            lock (_lock)
            {
                _instance = new T();
            }
        }
    }
}
