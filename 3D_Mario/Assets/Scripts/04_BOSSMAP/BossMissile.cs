using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMissile : BossBullet
{
    public Transform Target;
    private NavMeshAgent nav;
    
    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Target.transform.position);
    }
}
