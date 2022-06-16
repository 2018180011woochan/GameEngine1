using System;
using UnityEngine;

namespace YSK_SCRIPSTS
{
    [CreateAssetMenu(order = 0, fileName = "PrefabDataBase", menuName = "YSK/Create Prefab DB")]
    public class ManagedPrefabDataBase : ScriptableObject
    {
        public ManagedPrefab[] prefabs;
    }

    [Serializable]
    public class ManagedPrefab
    {
        public string prefabName;
        public GameObject prefabGameObject;
    }
}