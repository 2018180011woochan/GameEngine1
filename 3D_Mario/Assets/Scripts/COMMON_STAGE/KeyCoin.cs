using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCoin : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, -10f, 0) * Time.deltaTime * 10f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
