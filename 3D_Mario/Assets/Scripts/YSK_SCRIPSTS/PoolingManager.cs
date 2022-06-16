using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using YSK_SCRIPSTS;


public class PoolingManager : BASIC_SINGLETON<PoolingManager>
{
    public ManagedPrefabDataBase prefabDataBase;

    private Dictionary<string, GameObject> _prefabDics;
    private Dictionary<string, List<GameObject>> _managedGameObjects;

    private void Awake()
    {
       _prefabDics = new Dictionary<string, GameObject>();
        _managedGameObjects = new Dictionary<string, List<GameObject>>();

        foreach (var item in prefabDataBase.prefabs)
        {
            _prefabDics.Add(item.prefabName, item.prefabGameObject);
        }
    }

    // position rotation ���... �߰� ����.. �����ε�..
    public GameObject Get(string prefabName, Vector3 position, Quaternion rotation)
    {
        if (!_prefabDics.ContainsKey(prefabName))
        {
            print("[" + prefabName + "] is not enable prefabname");
            return null;
        }

        if (!_managedGameObjects.ContainsKey(prefabName))
        {
            _managedGameObjects.Add(prefabName, new List<GameObject>());
        }

        var inactiveObject = _managedGameObjects[prefabName].Find(x => !x.activeInHierarchy);
        if (inactiveObject)
        {
            inactiveObject.SetActive(true);
            inactiveObject.transform.position = position;
            inactiveObject.transform.rotation = rotation;
            return inactiveObject;
        }
        else
        {
            var newObject = Instantiate(_prefabDics[prefabName], position, rotation, null);
            _managedGameObjects[prefabName].Add(newObject);
            return newObject;
        }
    }


    public GameObject Get(string prefabName)
    {
        return Get(prefabName, Vector3.zero, Quaternion.identity);
    }
}
