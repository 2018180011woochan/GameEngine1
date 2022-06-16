using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6Manager : MonoBehaviour
{
    public GameObject[] koopa;
    public GameObject door;

    bool isOpen = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!koopa[0].gameObject.activeSelf && !koopa[1].gameObject.activeSelf)
            door.GetComponent<Door_Common>().SetOpen();
    }
}
