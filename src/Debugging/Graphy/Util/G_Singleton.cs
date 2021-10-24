using UnityEngine;

namespace Appalachia.Editing.Debugging.Graphy.Util
{
    /// <summary>
    ///     Be aware this will not prevent a non singleton constructor
    ///     such as `T myT = new T();`
    ///     To prevent that, add `protected T () {}` to your singleton class.
    /// </summary>
    public class G_Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
#region Properties -> Public

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        Debug.Log(
                            "[Singleton] An instance of " +
                            typeof(T) +
                            " is trying to be accessed, but it wasn't initialized first. " +
                            "Make sure to add an instance of " +
                            typeof(T) +
                            " in the scene before " +
                            " trying to access it."
                        );
                    }

                    return _instance;
                }
            }
        }

#endregion

#region Variables -> Private

        private static T _instance;

        private static readonly object _lock = new();

#endregion

#region Methods -> Unity Callbacks

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = GetComponent<T>();
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

#endregion
    }
}
