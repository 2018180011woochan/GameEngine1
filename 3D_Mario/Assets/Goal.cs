using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WORLDMAP_UI.H.FadeStart();
            LOAD_MNG.LoadScene("02_WORLDMAP");
        }
    }
}
