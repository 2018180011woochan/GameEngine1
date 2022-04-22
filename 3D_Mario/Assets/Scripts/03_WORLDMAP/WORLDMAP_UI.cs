using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WORLDMAP_UI : BASIC_SINGLETON<WORLDMAP_UI>
{
    public Image _img;
    public GameObject _Panel;
    private bool onPanel = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPanel)
            {
                _Panel.SetActive(true);
                onPanel = false;
            }
            else
            {
                _Panel.SetActive(false);
                onPanel = true;
            }
        }

    }

    public void FadeStart()
    {
        StartCoroutine(FadeCount());
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

    public void WORLDMAP_BUTTON()
    {
        LOAD_MNG.LoadScene("02_WORLDMAP");
    }

    public void EXIT_BUTTON()
    {
        Application.Quit();
    }
}
