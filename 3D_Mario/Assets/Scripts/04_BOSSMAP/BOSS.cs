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
    
    private Vector3 MoveDir = new Vector3(0,0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isMove", true);
        Move();
        Attack();
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
}
