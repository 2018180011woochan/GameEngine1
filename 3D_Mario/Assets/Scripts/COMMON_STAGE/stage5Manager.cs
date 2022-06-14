using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage5Manager : MonoBehaviour
{
    public int coinCnt;
    public GameObject[] coins;
    public GameObject door;

    bool isOpen = false;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        if (isOpen)
            door.GetComponent<CoinDoor>().SetOpen();

        CheckCoin();
    }

    void CheckCoin()
    {
        for (int i = 0; i < coinCnt; ++i)
        {
            if (coins[i].gameObject.activeSelf)
            {
                isOpen = false;
                return;
            }
        }

        isOpen = true;
    }
}
