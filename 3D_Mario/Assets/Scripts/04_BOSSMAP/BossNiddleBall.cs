using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNiddleBall : BossBullet
{
    private Rigidbody rigid;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigid.AddForce(Vector3.up, ForceMode.Impulse);
    }
}
