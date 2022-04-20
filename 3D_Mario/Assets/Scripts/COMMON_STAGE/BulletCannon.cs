using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCannon : MonoBehaviour
{
    public enum DIR { LEFT, RIGHT };
    public DIR dir;

    public Transform bulletPos;
    public GameObject bullet;

    void Awake()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            // bullet น฿ป็
            if (dir == DIR.LEFT)
            {
                GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            }

            else if (dir == DIR.RIGHT)
            {
                GameObject instantBullet = Instantiate(bullet, bulletPos.position, Quaternion.Euler(0f, -90f, 0f));
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
