using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peach : MonoBehaviour
{
    private BoxCollider boxCollider;
    public GameObject EndingCamera;
    public GameObject EndingTimeLine;

    private bool isEnd;
    private float endTime;
    private void Awake()
    {
        isEnd = false;
        boxCollider = GetComponent<BoxCollider>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("공주구출 성공");
            isEnd = true;
            
            EndingCamera.SetActive(true);
            EndingTimeLine.SetActive(true);
        }
    }

    private void Update()
    {
        if (isEnd)
            endTime += Time.deltaTime;
        
        if (endTime > 5.0)
            LOAD_MNG.LoadScene("02_WORLDMAP");
    }
}
