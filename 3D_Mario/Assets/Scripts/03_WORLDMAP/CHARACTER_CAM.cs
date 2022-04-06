using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARACTER_CAM : MonoBehaviour
{
    public GameObject Player;

    public float CameraX = 0f;
    public float CameraY = 25f;
    public float CameraZ = -35f;
    public float CameraSpeed = 1.0f;
    Vector3 CAMERA_POSITION;
    void Start()
    {
        
    }


    void LateUpdate()
    {
        CAMERA_POSITION.x = Player.transform.position.x + CameraX;
        CAMERA_POSITION.y = Player.transform.position.y + CameraY;
        CAMERA_POSITION.z = Player.transform.position.z + CameraZ;

        transform.position = Vector3.Lerp(transform.position, CAMERA_POSITION, CameraSpeed * Time.deltaTime);

    }
}
