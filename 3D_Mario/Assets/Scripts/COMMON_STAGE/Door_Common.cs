using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Common : MonoBehaviour
{
    public bool isOpen = false;
    bool isPlaySound = false;
    Animator anim;

    AudioSource audioSource;
    public AudioClip audioDoor;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (isOpen)
        {
            if (!isPlaySound)
            {
                audioSource.clip = audioDoor;
                audioSource.Play();

                isPlaySound = true;
            }

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
