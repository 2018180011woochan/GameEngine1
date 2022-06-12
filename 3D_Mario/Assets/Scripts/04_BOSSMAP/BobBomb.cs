using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BobBomb : MonoBehaviour
{
    //public GameObject target;
    //public GameObject Boss;
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
            transform.position = Vector3.MoveTowards(transform.position, Boss.transform.position, 50 * Time.deltaTime);

        if (isChase && !isShoot)
            nav.SetDestination(target.transform.position);

        if (isDown)
        {
            gameObject.tag = "bomb";
        }
        else
        {
            gameObject.tag = "Bobomb";
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            if (isDown)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
                isDown = false;
                isShoot = false;
                isChase = true;
                
            }
            else
            {
                isDown = false;
            }
        }
        
        if (collision.gameObject.tag == "Player")
        {
            if (isDown)
            {
                ShotToBoss();
            }
            else
            {
                Debug.Log("플레이어와충돌");
                if (collision.gameObject.transform.position.y > 1)
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
