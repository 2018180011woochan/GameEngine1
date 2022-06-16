using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    private BoxCollider boxCollider;
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("gpgp");
        }
    }
}
