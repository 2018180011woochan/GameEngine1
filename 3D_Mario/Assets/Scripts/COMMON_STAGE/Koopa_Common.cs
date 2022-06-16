using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Koopa_Common : MonoBehaviour
{
    public Transform target;
    public GameObject NakedKoopa;
    public GameObject Shell;

    bool isChase;

    Rigidbody rigid;
    NavMeshAgent nav;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isChase", true);
    }

    void Update()
    {
        if (target.position.z >= 110f)
            Invoke("ChaseStart", 0.5f);

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
        float targetRadius = 0.5f;
        float targetRange = 0.5f;

        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
            targetRadius,
            transform.forward,
            targetRange,
            LayerMask.GetMask("Player"));
    }

    void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                isChase = true;
                nav.enabled = true;

                anim.SetBool("isChase", true);
                anim.SetBool("isAttack", false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChase = false;
            nav.enabled = false;

            anim.SetBool("isChase", false);
            anim.SetBool("isAttack", true);

            if (GameObject.Find("Mario").GetComponent<CHARACTER>().ISGROUND == false)
            {
                Rigidbody rigidPlayer = target.GetComponent<Rigidbody>();
                rigidPlayer.AddForce(transform.up * 15f, ForceMode.Impulse);

                GameObject instantNakedKoopa = Instantiate(NakedKoopa, transform.position, transform.rotation);
                Rigidbody rigidNakedKoopa = instantNakedKoopa.GetComponent<Rigidbody>();
                rigidNakedKoopa.AddForce(transform.forward * 10f, ForceMode.Impulse);

                GameObject instantShell = Instantiate(Shell, transform.position, transform.rotation);
                Rigidbody rigidShell = instantShell.GetComponent<Rigidbody>();
                rigidNakedKoopa.AddForce(transform.up * 15f, ForceMode.Impulse);

                gameObject.SetActive(false);
            }
        }
    }
}
