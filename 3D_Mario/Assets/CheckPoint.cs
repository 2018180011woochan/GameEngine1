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
            // ��ƼŬ ȿ�� ������ ������
            print("SetCheckPoint");
        }
    }
}
