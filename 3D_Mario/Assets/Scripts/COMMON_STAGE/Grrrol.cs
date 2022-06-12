using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grrrol : MonoBehaviour
{
    Transform trans;
    float speed = 0.07f;
    public bool isRight;

    void Awake()
    {
        trans = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // -7 ~ 7
        if (isRight)
        {
            trans.Translate(Vector3.right * speed);
            if (trans.position.x >= 7f)
            {
                isRight = false;
                trans.localScale = new Vector3(-1, 1, 1);
            }
        }

        else
        {
            trans.Translate(Vector3.left * speed);
            if (trans.position.x <= -7f)
            {
                isRight = true;
                trans.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    Destroy(gameObject);
        //}
    }
}
