using UnityEngine;
using System.Collections;

public class BASIC_SINGLETON<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    
    public static T H
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    Debug.Log("Null : " + instance.ToString());
                    return null;
                }
            }

            return instance;
        }
    }
}
