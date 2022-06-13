using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    void Awake()
    {
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, 10);
        //transform.Rotate(Vector3.up * Time.deltaTime * 1000f);
        //transform.Translate(new Vector3(0, 0, -1f));
        transform.Translate(Vector3.left * Time.deltaTime * 1f);

    }
}
