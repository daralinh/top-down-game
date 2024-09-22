using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance != null && this.gameObject != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
