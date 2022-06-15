using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND_MNG : BASIC_SINGLETON<SOUND_MNG>
{
    public AudioClip AudioJump1;
    public AudioClip AudioJump2;
    public AudioClip AudioJump3;
    public AudioClip AudioCoin;

    AudioSource audioSource;
    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP":
            {
                    var rand = Random.Range(0, 3);
                    if (rand == 0)
                    {
                        audioSource.clip = AudioJump1;
                    }
                    else if (rand == 1)
                    {
                        audioSource.clip = AudioJump2;
                    }
                    else if(rand == 2)
                    {
                        audioSource.clip = AudioJump3;
                    }
            }
            break;

            case "COIN":
                audioSource.clip = AudioCoin;
                break;
        }
        audioSource.Play();
    }
}
