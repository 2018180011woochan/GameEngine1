using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public GameObject _player;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    float BossSpeed = 0.1f;
    private float PlayerDistance;
    private float Timer;
    private bool ISGROUND = true;
    
    private Vector3 MoveDir = new Vector3(0,0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator.SetBool("isMove", true);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_animator.SetBool("isMove", true);
        if (_animator.GetBool("isMove"))
        {
            Move();
            Attack();   
            Jump();
        }
    }

    void Move()
    {
        MoveDir = _player.transform.position - transform.position;
        transform.position += MoveDir * BossSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MoveDir), Time.deltaTime * 5);
    }

    void Attack()
    {
        PlayerDistance = Vector3.Distance(_player.transform.position, transform.position);

        if (PlayerDistance < 5)
        {
            _animator.SetBool("isAttack", true);
        }
        else
        {
            _animator.SetBool("isAttack", false);
        }
    }

    void Jump()
    {
        // 임시로 3초후에 점프하게 나중에 FSM으로 바꿀 예정
        Timer += Time.deltaTime;

        if (Timer > 3 && ISGROUND)
        {
            _animator.SetTrigger("Jump");
            _rigidbody.AddForce(Vector3.up * 40f, ForceMode.Impulse);
            ISGROUND = false;
        }

        if (transform.position.y > 60f)
        {
            _rigidbody.AddForce(Vector3.down * 5000f);
            transform.position += MoveDir * 20f * Time.deltaTime;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ISGROUND = true;
        }
    }
}
