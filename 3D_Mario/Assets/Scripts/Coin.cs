using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool accqired = false;
    private void OnTriggerEnter(Collider other)
    {
        if (accqired) return;

        var mario = other.gameObject.GetComponent<CHARACTER>();
        if (mario)
        {
            accqired = true;
            mario.coin++;
            print("coin :: " + mario.coin);
            StartCoroutine(AccquireEffetct());
        }
    }

    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * 720);
    }

    IEnumerator AccquireEffetct()
    {
        const float animateTime = 0.25f;
        const float halfanimateTime = animateTime / 2;
        float animateLength = transform.lossyScale.y * 0.5f;
        float animateSpeedScalar = animateLength / animateTime * 2;
        float animateSpeedperSec = animateSpeedScalar;
        var originpos = gameObject.transform.position;
        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {

            float animateSpeed = animateSpeedperSec * Time.deltaTime;
            if (_interval_time < halfanimateTime)
                gameObject.transform.position = originpos + Vector3.up * Mathf.Lerp(0, animateLength, _interval_time / halfanimateTime);
            else
                gameObject.transform.position = originpos + Vector3.up * Mathf.Lerp(animateLength, 0, (_interval_time - halfanimateTime) / halfanimateTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        gameObject.SetActive(false);
    }
}

