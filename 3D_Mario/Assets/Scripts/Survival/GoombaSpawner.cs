using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaSpawner : MonoBehaviour
{
    public ObjectPoolingManager poolingManager;

    private float spawnTime;
    private float cooldownTime;

    public int maxCount = 10;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 10f;
        cooldownTime = 0f;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTime += Time.deltaTime;
        if (cooldownTime >= spawnTime)
        {
            if (count < maxCount)
            {
                var position = transform.position;
                position.y += transform.localScale.y;
                //Instantiate(goomba, position, transform.rotation);
                poolingManager.Get("goomba", position, transform.rotation);
                cooldownTime = 0f;
                count++;
                //print("create goomba");
            }
        }
    }
}
