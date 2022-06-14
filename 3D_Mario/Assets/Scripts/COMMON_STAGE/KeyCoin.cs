using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCoin : MonoBehaviour
{
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, -10f, 0) * Time.deltaTime * 10f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("KeyCoin");
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
