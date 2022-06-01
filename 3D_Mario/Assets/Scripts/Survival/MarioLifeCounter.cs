using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarioLifeCounter : MonoBehaviour
{
    public MarioCollision mario;
    public TMP_Text text;

    void Update()
    {
        text.text = "X " + ((int)mario.life).ToString();
    }
}
