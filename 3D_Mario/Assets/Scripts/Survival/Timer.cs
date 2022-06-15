using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    public float time = 60f;

    void Awake()
    {
        time = 60f;
    }

    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        text.text = ((int)time).ToString();
    }
}
