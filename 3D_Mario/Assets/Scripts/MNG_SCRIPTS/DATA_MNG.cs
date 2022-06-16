using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DATA_MNG : BASIC_SINGLETON<DATA_MNG>
{
    [HideInInspector]
    public int CHARACTER_HP;
    [HideInInspector]
    public int CHARACTER_LIFE;
    [HideInInspector]
    public int CHARACTER_COIN;
    [HideInInspector]
    public int WORLD_TIMER;
    [HideInInspector]
    public bool WORLD_1;
    [HideInInspector]
    public bool WORLD_2;
    [HideInInspector]
    public bool WORLD_3;
    [HideInInspector]
    public bool WORLD_4;

    private void Awake()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/TestJson.json");
        if (fi.Exists)
        {
            string JsonLoad = File.ReadAllText(Application.dataPath + "/TestJson.json");
            
            PLAYERDATA mPlayerData = JsonUtility.FromJson<PLAYERDATA>(JsonLoad);
            CHARACTER_HP = mPlayerData.DATA_CHARACTER_HP;
            Debug.Log(mPlayerData.DATA_CHARACTER_HP);
            CHARACTER_COIN = mPlayerData.DATA_COIN;
            Debug.Log(mPlayerData.DATA_COIN);
            WORLD_TIMER = 500;

        }
        else
        {
            CHARACTER_HP = 5;
            CHARACTER_COIN = 0;
            WORLD_TIMER = 500;
            WORLD_1 = false;
            WORLD_2 = false;
            WORLD_3 = false;
            WORLD_4 = false;
        }
    }
    private void Start()
    {
       
        

    }
}
