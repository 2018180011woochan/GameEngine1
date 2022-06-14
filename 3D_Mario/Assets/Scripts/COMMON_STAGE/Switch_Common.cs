using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Common : MonoBehaviour
{
    public bool isPress = false;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.Find("Mario").GetComponent<CHARACTER>().ISGROUND == false)
            {
                anim.SetBool("isPress", true);
                isPress = true;
            }
        }
    }

}
