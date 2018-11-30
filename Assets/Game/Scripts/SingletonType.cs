using UnityEngine;

public class SingletonType<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("There is no script of type " + typeof(T) + " in the scene!");
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}