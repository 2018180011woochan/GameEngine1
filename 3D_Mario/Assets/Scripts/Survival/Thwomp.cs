using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public GameObject mario;

    private Rigidbody _rigidbody;
    private float coolDown;
    private float height;
    private bool reachDown;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        coolDown = 10f;
        height = 10f;
        reachDown = false;
    }

    private void FixedUpdate()
    {
        if (reachDown)
        {
            _rigidbody.useGravity = false;
            transform.Translate(transform.up * Time.fixedDeltaTime, Space.World);
            if (transform.position.y >= height) reachDown = false;
        }
        else
        {
            coolDown -= Time.fixedDeltaTime;
            if (coolDown > 0)
            {
                ChaseTarget();
            }
            else
            {
                AttackTarget();
            }
        }
    }

    void ChaseTarget()
    {
         var pos = mario.transform.position;
         pos.y = height;
         //transform.position = pos;
         var dir = pos - transform.position;
         transform.Translate(dir * Time.fixedDeltaTime, Space.World);
    }

    void AttackTarget()
    {
        _rigidbody.useGravity = true;
    }

    void OnCollisionEnter(Collision collision)
    {
       //if (collision.gameObject.CompareTag("Ground"))
       //{
            reachDown = true;
            coolDown = 10f;
        //}
    }
}
