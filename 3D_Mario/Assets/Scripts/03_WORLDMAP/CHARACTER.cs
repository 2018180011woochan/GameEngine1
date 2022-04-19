using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARACTER : MonoBehaviour
{
    private Animator ANIMATOR;
    private Rigidbody RIGIDBODY;
    public float CHARACTER_SPPED = 12.0f;
    float CHARACTER_ROTATE = 10.0f;
    public float JUMPFORCE = 120.0f;
    public bool ISGROUND = true;
    public GameObject Mario;
    public CAHRACTER_DUST _Dust;
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
        //!> 중력 가속도 -9.81 -> -40으로 수정. Edit - ProjectSetting - Physics
        if (Input.GetKey(KeyCode.Space) && ISGROUND)
        {
            //!> 위 방향으로 JUMPFORCE만큼 힘을 가함
            RIGIDBODY.AddForce(Mario.transform.up * JUMPFORCE);
            _Dust._Particle.Stop();
            ANIMATOR.SetTrigger("JUMP");
            ISGROUND = false;
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        //!> 캐릭터와 충돌한 물체의 태그가 Ground일때 점프 갱신
        if (collision.gameObject.CompareTag("Ground"))
        {
            ISGROUND = true;
            
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            if (DATA_MNG.H.CHARACTER_HP == 0)
            {
                DATA_MNG.H.CHARACTER_HP = 1;
                DATA_MNG.H.CHARACTER_LIFE -= 1;
                // 이후 게임오버 제작
            }
            else
            {
                DATA_MNG.H.CHARACTER_HP -= 1;
            }
        }
    }
}
