using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioCollision : MonoBehaviour
{
    public int life;
    private float vulnerableTime;

    void Start()
    {
        life = 5;
        vulnerableTime = 0f;
    }

    private void FixedUpdate()
    {
        vulnerableTime -= Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") ||
            collision.gameObject.CompareTag("Goomba"))
        {
            if (vulnerableTime <= 0f)
            {
                vulnerableTime = 1f;
                life -= 1;
            }
        }
    }
}
