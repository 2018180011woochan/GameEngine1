using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        // z: 63 ~ 77, x: -7 ~ 7
        if (transform.position.x <= -7f || transform.position.x >= 7f
            || transform.position.z <= 63f || transform.position.z >= 77f)
        {
            Destroy(gameObject);
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fence")
        {
            Destroy(gameObject);
        }
    }
}
