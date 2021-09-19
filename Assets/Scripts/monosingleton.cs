
using UnityEngine;

public class monosingleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    private static T instance = null;
    private static bool shuttingDown = false;
    private static object locker = new object();

    public static T Instance
    {
        get
        {
            if(shuttingDown)
            {
                Debug.LogWarning("[singleton] instance " + typeof(T) + "is already destroyed");
                return null;
            }
            lock(locker)
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                }
            }
            return instance;
        }
    }
    private void OnDestroy()
    {
        shuttingDown = true;
    }
    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }
}
