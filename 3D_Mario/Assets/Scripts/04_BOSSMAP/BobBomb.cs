using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobBomb : MonoBehaviour
{
    public Transform target;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
}
