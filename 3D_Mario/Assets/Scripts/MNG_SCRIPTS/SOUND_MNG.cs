using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND_MNG : BASIC_SINGLETON<SOUND_MNG>
{
    public AudioClip AudioJump1;
    public AudioClip AudioJump2;
    public AudioClip AudioJump3;
    public AudioClip AudioCoin;
    public AudioClip AudioDeath;
    public AudioClip AudioOuch1;
    public AudioClip AudioOuch2;
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
                    if (CHARACTER.isDeath == false)
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
                        else if (rand == 2)
                        {
                            audioSource.clip = AudioJump3;
                        }
                    }

            }
            break;

            case "COIN":
                if (CHARACTER.isDeath == false)
                    audioSource.clip = AudioCoin;
                break;
            case "DEATH":
                    audioSource.clip = AudioDeath;
                break;
            case "OUCH":
                {
                    if (CHARACTER.isDeath == false)
                    {
                        var rand = Random.Range(0, 2);
                        if (rand == 0)
                        {
                            audioSource.clip = AudioOuch1;
                        }
                        else if (rand == 1)
                        {
                            audioSource.clip = AudioOuch2;
                        }
                    }

                }
                break;
        }
        audioSource.Play();
    }
}
