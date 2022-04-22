using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class INTRO_FADEINOUT : MonoBehaviour
{
    public Image _img;
    private AudioSource Audio;
    public AudioClip Click;
    bool Press = false;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = Click;
        StartCoroutine(IntroCount());
    }
    void Update()
    {
        if (Press)
        {
            if (Input.anyKeyDown)
            {
                Press = false;
                Audio.Play();
                StartCoroutine(FadeCount());
                StartCoroutine(ChangeScene());
            }
        }
    }
    IEnumerator IntroCount()
    {
        yield return new WaitForSeconds(3.0f);
        Press = true;
    }
    IEnumerator FadeCount()
    {
        float ImgAlpha = 0;
        while (ImgAlpha < 1.0f)
        {
            ImgAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            _img.color = new Color(0, 0, 0, ImgAlpha);
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        LOAD_MNG.LoadScene("02_WORLDMAP");
    }
}
