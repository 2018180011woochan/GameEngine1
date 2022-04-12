using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTRO_MNG : MonoBehaviour
{
    public GameObject _Text;

    void Start()
    {
        StartCoroutine(PressAnyKeyCount());
    }


    IEnumerator PressAnyKeyCount()
    {
        yield return new WaitForSeconds(3.0f);
        _Text.SetActive(true);
    }
}
