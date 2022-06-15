using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PLAYERDATA
{
    public int DATA_COIN;
    public int DATA_CHARACTER_HP;
    public bool DATA_WORLD_1;
    public bool DATA_WORLD_2;
    public bool DATA_WORLD_3;
    public bool DATA_WORLD_4;
}

public class SAVEDATA_MNG : MonoBehaviour
{
    public static void SAVE_DATA()
    {
        PLAYERDATA playerdata = new PLAYERDATA();
        playerdata.DATA_CHARACTER_HP = DATA_MNG.H.CHARACTER_HP;
        playerdata.DATA_COIN = DATA_MNG.H.CHARACTER_COIN;

        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(playerdata));
    }
}
