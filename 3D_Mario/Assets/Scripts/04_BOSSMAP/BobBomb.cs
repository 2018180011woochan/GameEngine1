using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BobBomb : MonoBehaviour
{
    public Transform target;
    public Transform Boss;
    private BoxCollider boxCollider;
    private Animator anim;
    private Rigidbody rigid;
    private UnityEngine.AI.NavMeshAgent nav;
    private bool isDown;
    private bool isChase;
    private bool isShoot;
    private Vector3 MoveDir = new Vector3(0,0,0);
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        isDown = false;
        isChase = true;
        isShoot = false;
    }

    private void Update()
    {
        if (isShoot)
            transform.position = Vector3.MoveTowards(transform.position, Boss.position, 50 * Time.deltaTime);
        if (isChase && !isShoot)
            nav.SetDestination(target.position);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "Player")
        {
            if (isDown)
            {
                ShotToBoss();
            }
            else
            {
                StartCoroutine(Down());
            }
            
        }
    }

    IEnumerator Down()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isDown", true);
        gameObject.tag = "bomb";
        isChase = false;
        isDown = true;
        yield return new WaitForSeconds(5f);
        anim.SetBool("isRun", true);
        anim.SetBool("isDown", false);
        gameObject.tag = "Bobomb";
        isChase = true;
        isDown = false;
    }

    void ShotToBoss()
    {
        isShoot = true;
    }
    
}
