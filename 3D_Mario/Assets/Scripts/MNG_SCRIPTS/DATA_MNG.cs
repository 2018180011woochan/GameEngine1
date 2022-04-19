using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        CHARACTER_HP = 1;
        CHARACTER_LIFE = 3;
        CHARACTER_COIN = 0;
        WORLD_TIMER = 500;
    }
}
