using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSK_BulletBillCannon : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;

    public void Fire()
    {
        Instantiate(bullet, bulletPos.position, bulletPos.rotation, transform);
    }
}
