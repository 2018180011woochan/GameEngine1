using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Common : MonoBehaviour
{
    public bool isPress = false;
    Animator anim;

    AudioSource audioSource;
    public AudioClip audioSwitch;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if (GameObject.Find("Mario").GetComponent<CHARACTER>().ISGROUND == false)
            //{

            //}

            if (!isPress)
            {
                audioSource.clip = audioSwitch;
                audioSource.Play();
            }
            anim.SetBool("isPress", true);
            isPress = true;
        }
    }
}
