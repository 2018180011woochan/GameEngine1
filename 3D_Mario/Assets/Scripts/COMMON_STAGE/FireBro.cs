using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBro : MonoBehaviour
{
    public GameObject target;
    public Transform FireballPos;
    public GameObject FireBall;

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
        if (target.transform.position.z < 65f || target.transform.position.z > 80f)
            return;

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

                if (!isThrow)
                {
                    GameObject instantFireBall = Instantiate(FireBall, FireballPos.position, FireballPos.rotation);
                    Rigidbody rigidFireBall = instantFireBall.GetComponent<Rigidbody>();
                    Vector3 dir = target.transform.position - transform.position;
                    dir.y = 10;
                    rigidFireBall.AddForce(dir, ForceMode.Impulse);
                    isThrow = true;
                }
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.SetBool("isAttack", false);
                anim.SetBool("isWait", true);
            }
        }
    }
}
