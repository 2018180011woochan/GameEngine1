using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaTrigger : MonoBehaviour
{
    public GameObject goomba;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            goomba.GetComponent<Goomba>().SetStart();
        }
    }
}
