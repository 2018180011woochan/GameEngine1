using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARACTER : MonoBehaviour
{
    private Animator ANIMATOR;
    private Rigidbody RIGIDBODY;
    float CHARACTER_SPPED = 4.0f;
    float CHARACTER_ROTATE = 10.0f;
    float JUMPFORCE = 7.0f;
    private bool ISGROUND = true;
    private bool ACTIONKEY_ON = false;
    private bool ISCONTROLABLE = true;

    float h, v;
    void Start()
    {
        ANIMATOR = GetComponent<Animator>();
        RIGIDBODY = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (ISCONTROLABLE)
        {
            MOVE();
            JUMP();
            ACTION();
        }
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




    // vvv SUNKUE
    void ACTION()
    {
        ACTIONKEY_ON = Input.GetKey(KeyCode.LeftControl);
    }

    internal bool GET_ACTIONKEY_ON()
    {
        return ACTIONKEY_ON;
    }


    void ReadyPipeAnimate()
    {
        ACTIONKEY_ON = false;
        ISCONTROLABLE = false;
        RIGIDBODY.detectCollisions = false;
        RIGIDBODY.useGravity = false;
        RIGIDBODY.freezeRotation = true;
        RIGIDBODY.velocity = Vector3.zero;
        ANIMATOR.SetBool("IS_RUN", false);
    }

    void FinishPipeAnimate()
    {
        ISCONTROLABLE = true;
        RIGIDBODY.detectCollisions = true;
        RIGIDBODY.useGravity = true;
        RIGIDBODY.freezeRotation = false;
    }

    internal void OnPipeEnter(YSK_PIPE_HOLE_SCRIPT pipe)
    {
        ReadyPipeAnimate();
        transform.position = pipe.GetHolePositionOutside();
        StartCoroutine(AnimateOnPipeAction(pipe, true));
    }

    internal void OnPipeExit(YSK_PIPE_HOLE_SCRIPT pipe)
    {
        ReadyPipeAnimate();
        transform.position = pipe.GetHolePositionInside();
        StartCoroutine(AnimateOnPipeAction(pipe, false));
    }

    IEnumerator AnimateOnPipeAction(YSK_PIPE_HOLE_SCRIPT pipe, bool enter)
    {
        const float animateTime = 1f;
        const float animateLength = 3f;
        const float animateSpeedScalar = animateLength / animateTime;

        float animateSpeedperSec = animateSpeedScalar;

        if (enter)
        {
            animateSpeedperSec *= -1;
        }

        var localUp = pipe.transform.up;

        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            float animateSpeed = animateSpeedperSec * Time.deltaTime;
            transform.position += localUp * animateSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (enter)
        {
            pipe.PassedOut();
        }
        else
        {
            FinishPipeAnimate();
        }
    }
    // ^^^ SUNKUE
}
