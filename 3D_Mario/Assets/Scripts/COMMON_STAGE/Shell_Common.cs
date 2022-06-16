using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Common : MonoBehaviour
{
    float speed = 0.2f;
    float dir = 1f;
    bool isMove = true;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (isMove)
            transform.Translate(Vector3.forward * speed * dir);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fence")
        {
            dir *= -1f;
        }

        else if (collision.gameObject.tag == "Player")
        {
            if (GameObject.Find("Mario").GetComponent<CHARACTER>().ISGROUND == false)
            {
                Rigidbody rigidPlayer = collision.gameObject.GetComponent<Rigidbody>();
                rigidPlayer.AddForce(transform.up * 15f, ForceMode.Impulse);
                isMove = !isMove;
            }
        }
    }
}
