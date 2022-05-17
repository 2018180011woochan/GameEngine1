using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage;
    public bool isMelee;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject, 3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isMelee && other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
        }
    }
}
