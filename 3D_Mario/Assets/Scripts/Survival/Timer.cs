using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    private float time;

    void Awake()
    {
        time = 100f;
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;
        text.text = ((int)time).ToString();
    }
}
