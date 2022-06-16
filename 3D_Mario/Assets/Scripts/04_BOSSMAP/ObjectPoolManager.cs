using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    [Serializable]
    public struct PrefabObjectKeyValuePair
    {
        public string name;
        public GameObject prefab;
    }

    public List<PrefabObjectKeyValuePair> managedPrefabs;

    private Dictionary<string, List<GameObject>> _objectPool;

        
    private void Awake()
    {
        Instance = this;
        _objectPool = new Dictionary<string, List<GameObject>>();
    }

    public GameObject Spawn(string spawnObjectName, Vector3 position = default, Quaternion rotate = default)
    {
        if (false == managedPrefabs.Exists(keyValuePair => keyValuePair.name == spawnObjectName))
        {
            print($"{spawnObjectName} prefab은 존재하지 않습니다.");
            return null;
        }

        var foundedPrefabData = managedPrefabs.FirstOrDefault((pair => pair.name == spawnObjectName));
            
        if(false == _objectPool.ContainsKey(spawnObjectName))
            _objectPool.Add(spawnObjectName,new List<GameObject>());

        var founded = _objectPool[spawnObjectName].FirstOrDefault((go => !go.activeInHierarchy));
            
        if(founded != null)
            founded.SetActive(true);
        else
        {
            founded = Instantiate(foundedPrefabData.prefab);
            _objectPool[spawnObjectName].Add(founded);
        }

            

        if (position != default) founded.transform.position = position;
        if (rotate != default) founded.transform.rotation = rotate;

        return founded;
    }
}
