using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CHARACTER_UI : MonoBehaviour
{
    public TextMeshProUGUI COIN_TEXT;
    int Ten, One;

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
            // life + 1
        }
        else
        {
            One += 1;
        }

        COIN_TEXT.text = "<sprite name=\"MarioNum_" + Ten.ToString() + "\" color=#ffff00> <sprite name=\"MarioNum_" + One.ToString() + "\" color=#ffff00>";
    }
}
