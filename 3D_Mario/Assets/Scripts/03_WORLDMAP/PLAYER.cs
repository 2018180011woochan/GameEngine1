using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    private Animator ANIMATOR;
    private Rigidbody RIGIDBODY;
    float CHARACTER_SPPED = 4.0f;
    float CHARACTER_ROTATE = 10.0f;
    float JUMPFORCE = 7.0f;
    private bool ISGROUND = true;

    float h, v;
    void Start()
    {
        ANIMATOR = GetComponent<Animator>();
        RIGIDBODY = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MOVE();
        JUMP();

    }
    void MOVE()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * CHARACTER_SPPED * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * CHARACTER_ROTATE);
            ANIMATOR.SetBool("IS_RUN", true);

        }
        else
        {
            ANIMATOR.SetBool("IS_RUN", false);
        }
    }

    void JUMP()
    {
        if (Input.GetKey(KeyCode.Space) && ISGROUND)
        {
            //!> 위 방향으로 JUMPFORCE만큼 힘을 가함, Impulse>>순간적인 힘으로 무게 적용
            RIGIDBODY.AddForce(Vector3.up * JUMPFORCE, ForceMode.Impulse);
            ISGROUND = false;
            ANIMATOR.SetTrigger("JUMP");
        }
    }

    //!> 캐릭터와 충돌한 물체의 태그가 Ground일때 점프 갱신
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ISGROUND = true;
        }
    }
}
