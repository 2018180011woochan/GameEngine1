using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemy : MonoBehaviour
{
    private AudioSource _audioSource;
    
    public int maxHealth;
    public int curHealth;
    public Transform target;
    public BoxCollider meleeArea;
    public BoxCollider Head;
    public GameObject bullet;
    public GameObject NiddleBall;
    public GameObject Bobomb;
    public bool isChase;
    public bool isAttack;
    public GameObject _dust;
    public Transform DoorTransform;
    
    private Vector3 MoveDir = new Vector3(0,0,0);
    
    private Rigidbody rigid;
    private BoxCollider boxCollider;
    private NavMeshAgent nav;
    private Animator anim;

    private Vector3 lookVec;
    private Vector3 tauntVec;
    public bool isLook;
    private bool isDamaged;
    private bool isDead;

    private float mytime;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Head = GetComponent<BoxCollider>();
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        mytime = 0;
        nav.isStopped = true;
        Invoke("ChaseStart", 2.0f);
        StartCoroutine(Think());
        isLook = true;
        maxHealth = 1000;
        curHealth = 1000;
        isDead = false;
    }

    void ChaseStart()
    {
        isChase = true;

        anim.SetBool("isWalk", true);
    }

    private void Update()
    {
        mytime += Time.deltaTime;
        if (mytime < 2.0f)
            return;

        if (curHealth <= 0)
        {
            anim.SetTrigger("doDead");
            isDead = true;
            
            if (DoorTransform.transform.position.y > -90)
                DoorTransform.Rotate(new Vector3(0, -10 * Time.deltaTime, 0));
        }
        
        if (isLook)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 5f;
        }

        if (nav.enabled)
       {
           if (!isDamaged)
           {
               if (!isDead)
               {
                   nav.SetDestination(target.position);
                   nav.isStopped = !isChase;
               }
           }
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
        if (!isDead)
        {
            yield return new WaitForSeconds(0.1f);

            int ranAction = UnityEngine.Random.Range(0, 5);

            switch (ranAction)
            {
                case 0:
                case 1:
                    // 플레이어 쫓아가는 패턴
                    if (mytime < 2.0f)
                    {
                        StartCoroutine(Think());
                        break;
                    }
                        
                    StartCoroutine(ChasePlayer());
                    break;
                case 2:
                    // 돌격공격 패턴
                    if (mytime < 2.0f)
                    {
                        StartCoroutine(Think());
                        break;
                    }
                    StartCoroutine(Dash());
                    break;
                case 3:
                    // 돌굴러가는 패턴
                    if (mytime < 2.0f)
                    {
                        StartCoroutine(Think());
                        break;
                    }
                    StartCoroutine(RockShot());
                    break;
                case 4:
                    // 몬스터소환 패턴
                    if (mytime < 2.0f)
                    {
                        StartCoroutine(Think());
                        break;
                    }
                    StartCoroutine(FireMissile());
                    break;
            }
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
        if (!isDamaged)
        {
            anim.SetTrigger("doRock");
        }
        Debug.Log("rockshot");
        isChase = false;
        
        Instantiate(bullet, transform.position, transform.rotation);
        
        yield return new WaitForSeconds(3f);
        isChase = true;
        StartCoroutine(Think());
    }
    
    IEnumerator Dash()
    {
        if (!isDamaged)
        {
            anim.SetBool("isDash", true);
        }
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
        if (!isDamaged)
        {
            anim.SetTrigger("doFire");
        }
        Debug.Log("FireMissile");
        isChase = false;
        
        //Instantiate(NiddleBall, transform.position, transform.rotation);
        //Instantiate(Bobomb, transform.position, transform.rotation);
        ObjectPoolManager.Instance.Spawn("Bobomb", transform.position);
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
            StartCoroutine(OnDamage());
        }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (target.transform.position.y > 3)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("ok");
                anim.SetTrigger("doDamaged");
                StartCoroutine(OnDamage());
            }
        }

        if (collision.gameObject.tag == "bomb")
        {
            Debug.Log("으악");
            anim.SetTrigger("doDamaged");
            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {
        this._audioSource.Play();
        isDamaged = true;
        curHealth -= 150;
        if (curHealth < 0)
            curHealth = 0;
        Debug.Log(curHealth);
        yield return new WaitForSeconds(2.0f);
        isDamaged = false;

        if (curHealth > 0)
        {
            //mat.color = Color.white;
        }
    }

}
