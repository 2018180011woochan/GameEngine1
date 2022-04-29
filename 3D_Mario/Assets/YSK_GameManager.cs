using UnityEngine;

public class GameManagerSC : MonoBehaviour
{
    private static GameManagerSC _instance;

    public PoolingManager poolingManager;


    public static GameManagerSC Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManagerSC>();

                if (!_instance)
                {
                    GameObject go = new GameObject();
                    go.AddComponent<GameManagerSC>();
                    _instance = go.GetComponent<GameManagerSC>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
    }
}
