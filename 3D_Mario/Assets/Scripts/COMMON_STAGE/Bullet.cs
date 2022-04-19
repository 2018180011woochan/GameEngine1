using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform trans;
    Rigidbody rigid;

    float speed = 0.5f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        trans.Translate(Vector3.forward * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
