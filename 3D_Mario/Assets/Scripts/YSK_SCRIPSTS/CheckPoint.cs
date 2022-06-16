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
            var respawnPoint = transform.position + Vector3.up * 2;
            charactor.SetRespawn(respawnPoint);
            // ��ƼŬ ȿ�� ������ ������
            print("SetCheckPoint");
        }
    }
}
