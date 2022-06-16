using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goomba : MonoBehaviour
{
    public Transform target;
    public bool isChase;
    public bool isAttack;

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Animator anim;

    AudioSource audioSource;
    public AudioClip audioGoomba;

    void Awake()
    {
        target = GameObject.Find("Mario").transform;
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetStart()
    {
        Invoke("ChaseStart", 0.5f);
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
        float targetRadius = 0.5f;
        float targetRange = 0.5f;

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
        if (collision.gameObject.tag == "Player")
        {
            isChase = false;
            nav.enabled = false;

            if (GameObject.Find("Mario").GetComponent<CHARACTER>().ISGROUND == false)
            {
                Rigidbody rigidPlayer = target.GetComponent<Rigidbody>();
                rigidPlayer.AddForce(transform.up * 20f, ForceMode.Impulse);
                gameObject.SetActive(false);

                audioSource.clip = audioGoomba;
                audioSource.Play();
            }

            else
            {
                gameObject.tag = "Goomba";
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChase = true;
            nav.enabled = true;
        }

        gameObject.tag = "Monster";
    }
}
