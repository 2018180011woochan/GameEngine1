using UnityEngine;

public class BASIC_SINGLETON<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    public static T H
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<T>();

                if (!instance)
                {
                    GameObject go = new GameObject();
                    go.AddComponent<T>();
                    instance = go.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}

