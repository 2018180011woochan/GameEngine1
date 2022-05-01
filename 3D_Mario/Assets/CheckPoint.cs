using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var charactor = other.gameObject.GetComponent<CHARACTER>();
            charactor.SetRespawn(transform.position);
            // 파티클 효과 났으면 좋겠음
            print("SetCheckPoint");
        }
    }
}
