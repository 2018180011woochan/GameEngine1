using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;

    private float spawnTime;
    private float spawnCooldownTime;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(7f, 10f);
        spawnCooldownTime = 0f;
        count = 0;
    }

    void spawnObject()
    {
        var position = transform.position;
        position.y += transform.localScale.y * 0.7f;
        Instantiate(bullet, position, transform.rotation);
        count += 1;
        print("create bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            CancelInvoke("spawnObject");
            count = 0;
        }

        if (count == 0)
        {
            spawnCooldownTime += Time.deltaTime;
        }
        
        if (spawnCooldownTime >= spawnTime)
        {
            InvokeRepeating("spawnObject", 1f, 3f);
            spawnCooldownTime = 0f;
            spawnTime = Random.Range(5f, 10f);
            print("start create bullet");
        }
    }
}
