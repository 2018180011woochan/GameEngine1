using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : MonoBehaviour
{
    //public GameObject[] Brick;
    public GameObject Goomba;
    public GameObject door;
    public GameObject[] switches;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        CheckDoor();
    }

    void CheckDoor()
    {
        // door 1 - Goomba & Switch
        if (!Goomba.activeSelf
            && switches[0].GetComponent<Switch_Common>().isPress
            && switches[1].GetComponent<Switch_Common>().isPress)
        {
            door.GetComponent<Door_Common>().SetOpen();
        }
    }
}
