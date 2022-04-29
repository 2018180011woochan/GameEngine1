using System;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(order = 0, fileName = "PrefabDataBase", menuName = "YSK/Create Prefab DB")]
public class ManagedPrefabDataBase : ScriptableSingleton<ManagedPrefabDataBase>
{
    public ManagedPrefab[] prefabs;
}

[Serializable]
public class ManagedPrefab
{
    public string prefabName;
    public GameObject prefabGameObject;
}
