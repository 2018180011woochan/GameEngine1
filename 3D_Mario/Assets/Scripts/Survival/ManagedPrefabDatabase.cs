using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "PrefabDatabase", menuName = "Create Prefab DB")]
public class ManagedPrefabDatabase : ScriptableObject
{
    public ManagedPrefab[] Prefabs;
}

[Serializable]
public class ManagedPrefab
{
    public string prefabName;
    public GameObject prefabGameObject;
}