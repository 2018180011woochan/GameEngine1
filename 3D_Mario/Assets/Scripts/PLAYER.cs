using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    float CHARACTER_SPPED = 2.0f;
    float CHARACTER_ROTATE = 10.0f;
    float h, v;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * CHARACTER_SPPED * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * CHARACTER_ROTATE);
        }
    }
}
