using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSK_BulletBill : MonoBehaviour
{
    float speed = 15f;
 
    private void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("bulletCollide");
            GameObject.FindObjectOfType<YSK_CannonManager>().ReloadCannons();
            other.gameObject.GetComponent<CHARACTER>().Respawn();
        }
    }
}
