using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using Unity.VisualScripting;

public class BOSS : BossEnemy
{
    // public GameObject _player;
    // public GameObject _Boss;
    // public GameObject _dust;
    // public ParticleSystem dusteffect;
    //
    // private Animator _animator;
    // private Rigidbody _rigidbody;
    // float BossSpeed = 0.3f;
    // private float PlayerDistance;
    // private float Timer;
    // private bool ISGROUND = true;
    //
    // private Vector3 MoveDir = new Vector3(0,0,0);
    // private Vector3 lookVec;
    // private Vector3 TauntVec = new Vector3(0, 0, 0);
    // private bool isLook;
    //
    // public enum States
    // {
    //     Init,
    //     Walk,
    //     JumpAttack,
    //     Dead
    // }
    //
    // StateMachine<States> fsm;
    //
    // private void Awake()
    // {
    //     fsm = StateMachine<States>.Initialize(this);
    // }
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     fsm.ChangeState(States.Init);
    //     
    //     _animator = GetComponent<Animator>();
    //     _rigidbody = GetComponent<Rigidbody>();
    //     _animator.SetBool("isMove", true);
    //     
    //     fsm.ChangeState(States.Walk);
    // }
    //
    // void Init_Enter()
    // {
    //     Debug.Log("Init!");
    // }
    // void Walk_Enter()
    // {
    //     _animator.SetBool("isMove", true);
    // }
    //
    // void Walk_Update()
    // {
    //     Attack();
    //     Timer += Time.deltaTime;
    //
    //     if (Timer > 3)
    //     {
    //         MoveDir = _player.transform.position - transform.position;
    //         transform.position += MoveDir * BossSpeed * Time.deltaTime;
    //         transform.rotation =
    //             Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MoveDir), Time.deltaTime * 5);
    //         //lookVec = new Vector3(MoveDir.x, 0, MoveDir)
    //     }
    //     
    //     if (Timer > 5)
    //         fsm.ChangeState(States.JumpAttack);
    // }
    //
    // void JumpAttack_Enter()
    // {
    //     Debug.Log("Jump!");
    //     _animator.SetTrigger("Jump");
    // }
    //
    // void JumpAttack_Update()
    // {
    //     TauntVec = _player.transform.position + MoveDir;
    //
    //     // _rigidbody.AddForce(_Boss.transform.up * 3000f);
    //     // ISGROUND = false;
    //     //
    //     // _dust.transform.position = transform.position;
    //     // _dust.SetActive(true);
    //     //
    //     // if (transform.position.y > 40f)
    //     // {
    //     //     _rigidbody.AddForce(Vector3.down * 5000f);
    //     //     transform.position += MoveDir * 20f * Time.deltaTime;
    //     // }
    //     //
    //     // if (ISGROUND)
    //     // {
    //     //     Debug.Log("착지!");
    //     // }
    // }
    //
    // void Attack()
    // {
    //     PlayerDistance = Vector3.Distance(_player.transform.position, transform.position);
    //
    //     if (PlayerDistance < 6)
    //     {
    //         _animator.SetBool("isAttack", true);
    //     }
    //     else
    //     {
    //         _animator.SetBool("isAttack", false);
    //     }
    // }
    //
    // void Jump()
    // {
    //     Debug.Log("Jump!");
    //
    //     _animator.SetTrigger("Jump");
    //     _rigidbody.AddForce(_Boss.transform.up * 30f);
    //     ISGROUND = false;
    //
    //     _dust.transform.position = transform.position;
    //     _dust.SetActive(true);
    //     
    //     if (transform.position.y > 40f)
    //     {
    //         _rigidbody.AddForce(Vector3.down * 5000f);
    //         transform.position += MoveDir * 20f * Time.deltaTime;
    //     }
    // }
    //
    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         ISGROUND = true;
    //         print("Ground True");
    //     }
    // }
}
