using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (player.transform.position.z > 100)
                player.transform.position = new Vector3(0f, 0f, 132f);

            else
                player.transform.position = new Vector3(0f, 0f, -10f);
        }

        //if (GameObject.Find("Mario").GetComponent<CHARACTER>().ISGROUND == false)
        //    Debug.Log("Jump");
    }
}
