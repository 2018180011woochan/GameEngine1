using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ObjectPoolingManager : MonoBehaviour
{
    public ManagedPrefabDatabase prefabDatabase;
    private Dictionary<string, GameObject> _prefabDic;
    private Dictionary<string, List<GameObject>> _managedObjects;

    private void Awake()
    {
        _prefabDic = new Dictionary<string, GameObject>();
        _managedObjects = new Dictionary<string, List<GameObject>>();
        
        foreach (var managedPrefab in prefabDatabase.Prefabs)
        {
            _prefabDic.Add(managedPrefab.prefabName, managedPrefab.prefabGameObject);
        }
    }

    public GameObject Get2(string gameObjectName, Vector3 position, Quaternion rotation)
    {
        if (!_prefabDic.ContainsKey(gameObjectName)) return null;
        else
        {
            if(!_managedObjects.ContainsKey(gameObjectName))
                _managedObjects.Add(gameObjectName, new List<GameObject>());

            if (_managedObjects[gameObjectName].Any(obj => !obj.activeInHierarchy))
            {
                var possibleObject =
                    _managedObjects[gameObjectName].FirstOrDefault(obj => !obj.activeInHierarchy);
                possibleObject.SetActive(true);
                
                return possibleObject;
            }
            else
            {
                var newObject = Instantiate(_prefabDic[gameObjectName], position, rotation);
                _managedObjects[gameObjectName].Add(newObject);

                return newObject;
            }
        }
    }

    public GameObject Get(string gameObjectName, Vector3 position, Quaternion rotation)
    {
        var go = Get2(gameObjectName, position, rotation);
        go.transform.position = position;
        go.transform.rotation = rotation;

        return go;
    }
}
