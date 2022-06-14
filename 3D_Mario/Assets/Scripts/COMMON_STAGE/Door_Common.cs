using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Common : MonoBehaviour
{
    public bool isOpen = false;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isOpen)
        {
            //anim.SetBool("isChase", true);

            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("CloseWait"))
                {
                    anim.SetBool("isOpen", true);

                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                {
                    anim.SetBool("isOpenWait", true);

                }
            }
        }
    }

    public void SetOpen()
    {
        isOpen = true;
    }
}
