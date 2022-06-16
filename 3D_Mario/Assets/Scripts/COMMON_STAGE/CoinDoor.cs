using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDoor : MonoBehaviour
{
    Animator anim;
    public GameObject DoorKey;
    public GameObject KeyHole1;
    public GameObject KeyHole2;

    AudioSource audioSource;
    public AudioClip audioDoor;
    bool isPlaySound = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
            {
                anim.speed = 0f;
                DoorKey.SetActive(false);
                KeyHole1.SetActive(false);
                KeyHole2.SetActive(false);
            }
        }
    }

    public void SetOpen()
    {
        anim.SetBool("isOpen", true);

        if (!isPlaySound)
        {
            audioSource.clip = audioDoor;
            audioSource.Play();
            isPlaySound = true;
        }    

    }
}
