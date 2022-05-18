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
    private bool ACTIONKEY_ON = false;
    private bool ISCONTROLABLE = true;
    public bool ISGROUND = true;
    public int coin = 0;
    public GameObject Mario;
    public CAHRACTER_DUST _Dust;
    float h, v;

    Vector3 _RespawnPoint;
    bool _IsSuperJumping = false;

    void Start()
    {
        ANIMATOR = GetComponent<Animator>();
        RIGIDBODY = GetComponent<Rigidbody>();
        _RespawnPoint = transform.position;
    }

    void Update()
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
        //!> 중력 가속도 -9.81 -> -40으로 수정. Edit - ProjectSetting - Physics
        if (Input.GetKey(KeyCode.Space) && ISGROUND)
        {
            //!> 위 방향으로 JUMPFORCE만큼 힘을 가함
            RIGIDBODY.AddForce(Vector3.up * JUMPFORCE);
            _Dust._Particle.Stop();
            ANIMATOR.SetTrigger("JUMP");
            ISGROUND = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Epsilon < collision.relativeVelocity.y)
        {
            ISGROUND = true;
            _IsSuperJumping = false;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WORLD1-2"))
        {
            WORLDMAP_UI.H.FadeStart();
            LOAD_MNG.LoadScene("COMMON_STAGE");
        }
        else if (other.gameObject.CompareTag("WORLD1-3"))
        {
            WORLDMAP_UI.H.FadeStart();
            LOAD_MNG.LoadScene("Survival");
        }
        else if (other.gameObject.CompareTag("WORLD1-4"))
        {
            WORLDMAP_UI.H.FadeStart();
            LOAD_MNG.LoadScene("04_BOSSMAP");
        }
    }


    // vvv SUNKUE
    public void SetRespawn(Vector3 respawnPoint)
    {
        _RespawnPoint = respawnPoint;
    }

    // skill
    public void Respawn()
    {
        print("respawn");
        transform.position = _RespawnPoint;
        transform.rotation = Quaternion.identity;
        ISCONTROLABLE = true;
    }

    bool _IsDashing = false;
    float _origin_characterspeed;
    public void Dash()
    {
        if (!_IsDashing)
        {
            print("Dash");
            _IsDashing = true;
            _origin_characterspeed = CHARACTER_SPPED;
            StartCoroutine(DashCoroutine());
        }
    }

    IEnumerator DashCoroutine()
    {
        const float boostingtime = 2f;
        const float prespeedingtime = 1f;
        float _interval_time = 0f;


        for (; _interval_time <= prespeedingtime; _interval_time += Time.deltaTime)
        {
            CHARACTER_SPPED = Mathf.Lerp(CHARACTER_SPPED, _origin_characterspeed * 3.4f, Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (; _interval_time <= boostingtime; _interval_time += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }

        CHARACTER_SPPED = _origin_characterspeed;
        _IsDashing = false;
    }

    public void SuperJump()
    {
        if (!_IsSuperJumping)
        {
            print("SuperJump");
            _IsSuperJumping = true;
            RIGIDBODY.AddForce(Vector3.up * JUMPFORCE * 2);
            ANIMATOR.SetTrigger("JUMP");
            ISGROUND = false;
        }
    }

    void ACTION()
    {
        ACTIONKEY_ON = Input.GetKey(KeyCode.LeftControl);
    }

    public bool GET_ACTIONKEY_ON()
    {
        return ACTIONKEY_ON;
    }


    public void ReadyAnimate()
    {
        ACTIONKEY_ON = false;
        ISCONTROLABLE = false;
        RIGIDBODY.detectCollisions = false;
        RIGIDBODY.useGravity = false;
        RIGIDBODY.freezeRotation = true;
        RIGIDBODY.velocity = Vector3.zero;
        ANIMATOR.SetBool("IS_RUN", false);
    }

    public void FinishAnimate()
    {
        ISCONTROLABLE = true;
        RIGIDBODY.detectCollisions = true;
        RIGIDBODY.useGravity = true;
        RIGIDBODY.freezeRotation = false;
    }

    public void OnPipeEnter(YSK_PIPE_HOLE_SCRIPT pipe)
    {
        ReadyAnimate();
        transform.position = pipe.GetHolePositionOutside();
        StartCoroutine(AnimateOnPipeAction(pipe, true));
    }

    public void OnPipeExit(YSK_PIPE_HOLE_SCRIPT pipe)
    {
        ReadyAnimate();
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
            FinishAnimate();
        }
    }
    // ^^^ SUNKUE
}
