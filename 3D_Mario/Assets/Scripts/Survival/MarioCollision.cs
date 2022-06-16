using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioCollision : MonoBehaviour
{
    public int life;
    //private float vulnerableTime;

    void Start()
    {
        life = 5;
        //vulnerableTime = 0f;
    }
/*
    private void FixedUpdate()
    {
        vulnerableTime -= Time.fixedDeltaTime;

        if (life == 0)
        {
            SceneManager.LoadScene("02_WORLDMAP");
        }
    }*/
    /*
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet") ||
            collision.gameObject.CompareTag("Goomba") ||
            collision.gameObject.CompareTag("Spike")
            )
        {
            if (vulnerableTime <= 0f)
            {
                vulnerableTime = 1f;
                life -= 1;
            }
        }
    }*/
}
