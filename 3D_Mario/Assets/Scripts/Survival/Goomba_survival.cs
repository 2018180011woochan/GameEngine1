using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goomba_survival : MonoBehaviour
{
    private Transform target;
    public bool isChase;
    public bool isAttack;

    private Rigidbody rigid;
    private NavMeshAgent nav;
    private Animator anim;

    void Awake()
    {
        target = GameObject.Find("Mario").transform;
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Invoke("ChaseStart", 2);
    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isChase", true);
    }

    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }

    void Targeting()
    {
        float targetRadius = 0.4f;
        float targetRange = 0.4f;

        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
            targetRadius,
            transform.forward,
            targetRange,
            LayerMask.GetMask("Player"));

        if (rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);

        yield return new WaitForSeconds(0.5f);
        rigid.velocity = Vector3.zero;

        anim.SetBool("isWait", true);
        yield return new WaitForSeconds(0.5f);

        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);
        anim.SetBool("isWait", false);
    }

    void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isChase = false;
            nav.enabled = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            isChase = true;
            nav.enabled = true;
        }
    }
}
