using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
	private bool collide;
	private Vector3 direction;
    
    void Start()
    {
		collide = false;
		direction = new Vector3(0, 0, 1);
    }

    void FixedUpdate()
    {
		transform.Translate(direction * Time.deltaTime, Space.World);
		var axis = new Vector3(direction.z, 0, 0);
		transform.Rotate(axis * Time.deltaTime * 100f);
    }

	void OnCollisionEnter(Collision collision)
    {
		if(!collide)
        if (collision.gameObject.CompareTag("Brick"))
        {
     		direction.z *= -1;
			collide = true;
        }
    }

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Brick"))
        {
			collide = false;
        }
	}
}
