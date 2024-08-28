using Unity.VisualScripting;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    Debug.LogError($"Unable to find an instance of {typeof(T)}. Make sure there is at least one active object of type {typeof(T)} in the scene.");
                }
            }

            return instance;
        }

        set
        {
            instance = value;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            print(gameObject.name);
            print(instance.gameObject.name);
            Destroy(gameObject);
        }
    }
}