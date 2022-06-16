using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var mario = other.gameObject.GetComponent<CHARACTER>();
        if (mario)
        {
            FindObjectOfType<DATA_MNG>().CHARACTER_LIFE++;
            gameObject.SetActive(false);
        }
    }
}
