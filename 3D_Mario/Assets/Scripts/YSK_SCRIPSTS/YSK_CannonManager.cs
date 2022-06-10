using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSK_CannonManager : MonoBehaviour
{
    public float fireTime = 3f;
    public float animateTime = 3f;
    public float CannonDepth = 20f;

    YSK_BulletBillCannon[] cannons;
    bool actived = false;

    private void Start()
    {
        cannons = GetComponentsInChildren<YSK_BulletBillCannon>();

        ReloadCannons();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (actived) return;

        if (other.CompareTag("Player"))
        {
            actived = true;
            print("CannonActivite");
            StartCoroutine(ActiveCannons());
        }
    }

    public void ReloadCannons()
    {
        foreach (var cannon in cannons)
        {
            cannon.gameObject.transform.position -= Vector3.up * CannonDepth;
            cannon.gameObject.SetActive(false);
            actived = false;
        }
    }

    IEnumerator ActiveCannons()
    {
        float _animateTime = animateTime;
        float _fireTime = fireTime;
        float _cannonDepth = CannonDepth;

        Vector3[] originPositions = new Vector3[cannons.Length];

        for (int i = 0; i < cannons.Length; i++)
        {
            cannons[i].gameObject.SetActive(true);
            originPositions[i] = cannons[i].gameObject.transform.position;
        }


        for (float _interval_time = 0f; _interval_time <= _animateTime; _interval_time += Time.deltaTime)
        {
            float t = _interval_time / _animateTime;
            t = Mathf.Pow(t, 2);
            float move = Mathf.Lerp(0, _cannonDepth, t);

            for (int i = 0; i < cannons.Length; i++)
            {
                cannons[i].gameObject.transform.position = originPositions[i] + Vector3.up * move;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (float _interval_time = 0f; _interval_time <= _fireTime; _interval_time += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }

        foreach (var cannon in cannons)
        {
            cannon.Fire();
        }
    }
}
