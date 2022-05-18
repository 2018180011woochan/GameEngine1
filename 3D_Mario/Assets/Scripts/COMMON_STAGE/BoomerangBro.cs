using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBro : MonoBehaviour
{
    public GameObject target;
    public Transform BommerangPos;
    public GameObject boomerang;

    bool isAttack = false;
    bool isThrow = false;

    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("isWait", true);
        //StartCoroutine(Attack());
    }
    void Update()
    {


    }
    void FixedUpdate()
    {
        Targeting();
        Attack();
    }

    void Targeting()
    {
        if (!isAttack)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(dir).normalized;
        }
    }

    void ThrowBoomerang()
    {

    }

    void Attack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
            {
                anim.SetBool("isWait", false);
                anim.SetBool("isSign", true);
                isThrow = false;
                //Debug.Log("Wait");
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSign"))
            {
                anim.SetBool("isSign", false);
                anim.SetBool("isAttack", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                if (!isThrow)
                {
                    GameObject instantBoomerang = 
                        Instantiate(boomerang, BommerangPos.position, BommerangPos.rotation);

                    isThrow = true;
                }

                anim.SetBool("isAttack", false);
                anim.SetBool("isWait", true);
            }
        }
    }
}
