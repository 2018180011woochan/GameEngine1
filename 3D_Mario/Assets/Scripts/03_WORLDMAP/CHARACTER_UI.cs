using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CHARACTER_UI : BASIC_SINGLETON<CHARACTER_UI>
{
    public TextMeshProUGUI COIN_TEXT;
    int Ten, One;
    private void Start()
    {
        Ten = DATA_MNG.H.CHARACTER_COIN / 10;
        One = DATA_MNG.H.CHARACTER_COIN % 10;
        COIN_TEXT.text = "<sprite name=\"MarioNum_" + Ten.ToString() + "\" color=#ffff00> <sprite name=\"MarioNum_" + One.ToString() + "\" color=#ffff00>";
    }
    public void click()
    {
        if (Ten < 9 &&One == 9)
        {
            Ten += 1;
            One = 0;
        }
        else if (Ten == 9 && One == 9)
        {
            Ten = 0;
            One = 0;
            DATA_MNG.H.CHARACTER_HP += 1;
            DATA_MNG.H.CHARACTER_COIN = 0;
        }
        else
        {
            One += 1;
        }

        COIN_TEXT.text = "<sprite name=\"MarioNum_" + Ten.ToString() + "\" color=#ffff00> <sprite name=\"MarioNum_" + One.ToString() + "\" color=#ffff00>";
    }
}
