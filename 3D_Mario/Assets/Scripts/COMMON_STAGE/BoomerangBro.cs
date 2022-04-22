using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBro : MonoBehaviour
{
    public GameObject target;

    bool isAttack = false;

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

    //IEnumerator Attack()
    //{
    //    //yield return new WaitForSeconds(2f);


    //    anim.SetBool("isWait", false);
    //    anim.SetBool("isSign", true);

    //    yield return new WaitForSeconds(0.867f);

    //    anim.SetBool("isSign", false);
    //    anim.SetBool("isAttack", true);
    //    yield return new WaitForSeconds(0.833f);

    //    anim.SetBool("isAttack", false);
    //    anim.SetBool("isWait", true);
    //    anim.SetBool("isSign", false);

    //    yield return new WaitForSeconds(3f);    // wait중

    //    StartCoroutine(Attack());

    //    //// wait중임, 5초동안
    //    //yield return new WaitForSeconds(5f);
    //    //anim.SetBool("isWait", false);  // wait 끝남
    //    //anim.SetBool("isSign", true);   // sign 시작

    //    //// sign중임, 2초동안
    //    //yield return new WaitForSeconds(0.7f);
    //    //anim.SetBool("isSign", false);  // sign 끝남
    //    //anim.SetBool("isAttack", true);  // attack 시작
    //    //isAttack = true;

    //    //// attack중임, 1.5초동안
    //    //yield return new WaitForSeconds(1f);
    //    //anim.SetBool("isAttack", false);   // attack 끝남
    //    //anim.SetBool("isWait", true);   // wait 시작
    //    //isAttack = false;
    //    //while (true)
    //    //{

    //    //}
    //}

    void Attack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
            {
                anim.SetBool("isWait", false);
                anim.SetBool("isSign", true);
                //Debug.Log("Wait");
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSign"))
            {
                anim.SetBool("isSign", false);
                anim.SetBool("isAttack", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.SetBool("isAttack", false);
                anim.SetBool("isWait", true);
            }
        }
    }
}
