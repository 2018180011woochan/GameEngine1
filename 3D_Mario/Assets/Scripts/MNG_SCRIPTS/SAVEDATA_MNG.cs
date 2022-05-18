using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PLAYERDATA
{
    public int DATA_COIN;
    public int DATA_CHARACTER_HP;
    public int DATA_CHARACTER_LIFE;
}

public class SAVEDATA_MNG : MonoBehaviour
{

    public void SAVE_DATA()
    {
        PLAYERDATA playerdata = new PLAYERDATA();
        playerdata.DATA_CHARACTER_HP = DATA_MNG.H.CHARACTER_HP;
        playerdata.DATA_COIN = DATA_MNG.H.CHARACTER_COIN;
        playerdata.DATA_CHARACTER_LIFE = DATA_MNG.H.CHARACTER_LIFE;

        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(playerdata));
    }
}
