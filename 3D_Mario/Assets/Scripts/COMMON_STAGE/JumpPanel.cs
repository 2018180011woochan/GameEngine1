using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rigidPlayer = player.GetComponent<Rigidbody>();
            rigidPlayer.AddForce(transform.up * 20f, ForceMode.Impulse);
            rigidPlayer.AddForce(transform.forward * 20f, ForceMode.Impulse);
        }
    }
}
