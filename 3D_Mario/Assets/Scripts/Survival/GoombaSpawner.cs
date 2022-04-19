using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaSpawner : MonoBehaviour
{
    public GameObject goomba;

    private float spawnTime;
    private float cooldownTime;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 5f;
        cooldownTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTime += Time.deltaTime;
        if (cooldownTime >= spawnTime)
        {
            var position = transform.position;
            position.y += transform.localScale.y * 0.5f;
            Instantiate(goomba, position, transform.rotation);
            cooldownTime = 0f;
            //print("create goomba");
        }
    }
}
