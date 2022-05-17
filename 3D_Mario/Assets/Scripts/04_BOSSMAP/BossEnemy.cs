using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemy : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public Transform target;
    public BoxCollider meleeArea;
    public GameObject bullet;
    public bool isChase;
    public bool isAttack;
    public GameObject _dust;
    
    private Vector3 MoveDir = new Vector3(0,0,0);
    
    private Rigidbody rigid;
    private BoxCollider boxCollider;
    //private MeshRenderer meshs;
    private NavMeshAgent nav;
    private Animator anim;

    private Vector3 lookVec;
    private Vector3 tauntVec;
    public bool isLook;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        //meshs = GetComponentInChildren<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        nav.isStopped = true;
        Invoke("ChaseStart", 0.1f);
        StartCoroutine(Think());
        isLook = true;
    }

    void ChaseStart()
    {
        isChase = true;

        anim.SetBool("isWalk", true);
    }

    private void Update()
    {
        if (isLook)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 5f;
        }

        // if (anim.GetBool("isWalk"))
        // {
        //     isChase = true;
        // }
        // else
        // {
        //     isChase = false;
        // }
        
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

    void Targerting()
    {
        float targetRadius = 1.5f;
        float targetRange = 3f;
        
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
        
        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(1f);
        meleeArea.enabled = false;

        
        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = true;
        
        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = false;

        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);
    }
    
    
    IEnumerator Think()
    {
        yield return new WaitForSeconds(0.1f);

        int ranAction = UnityEngine.Random.Range(0, 5);

        switch (ranAction)
        {
            case 0:
            case 1:
                // 플레이어 쫓아가는 패턴
                StartCoroutine(ChasePlayer());
                break;
            case 2:
                // 돌격공격 패턴
                StartCoroutine(Dash());
                break;
            case 3:
                // 돌굴러가는 패턴
                StartCoroutine(RockShot());
                break;
            case 4:
                // 미사일쏘는 패턴
                StartCoroutine(FireMissile());
                break;
        }
    }

    IEnumerator ChasePlayer()
    {
        Debug.Log("chaseplayer");
        isChase = true;
        yield return new WaitForSeconds(3f);
        
        StartCoroutine(Think());
    }

    IEnumerator RockShot()
    {
        Debug.Log("rockshot");
        isChase = false;
        anim.SetTrigger("doRock");

        Instantiate(bullet, transform.position, transform.rotation);
        
        yield return new WaitForSeconds(3f);
        isChase = true;
        StartCoroutine(Think());
    }
    
    IEnumerator Dash()
    {
        anim.SetBool("isDash", true);
        Debug.Log("Dash");
        yield return new WaitForSeconds(1f);
        _dust.transform.position = transform.position;
        _dust.SetActive(true);
        nav.speed = 70f;
        yield return new WaitForSeconds(3f);
        _dust.SetActive(false);
        anim.SetBool("isDash", false);
        nav.speed = 7f;

        StartCoroutine(Think());
    }
    
    IEnumerator FireMissile()
    {
        Debug.Log("FireMissile");

        yield return new WaitForSeconds(3f);
        StartCoroutine(Think());
    }
    
    void FixedUpdate()
    {
        Targerting();
        FreezeVelocity();
        
        MoveDir = target.transform.position - transform.position;
        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MoveDir), Time.deltaTime * 5);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee")
        {
            curHealth -= 10;
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {

        yield return new WaitForSeconds(0.1f);

        reactVec = reactVec.normalized;
        reactVec += Vector3.up;
        rigid.AddForce(reactVec * 5, ForceMode.Impulse);
        
        if (curHealth > 0)
        {
            //mat.color = Color.white;
        }
    }

}
