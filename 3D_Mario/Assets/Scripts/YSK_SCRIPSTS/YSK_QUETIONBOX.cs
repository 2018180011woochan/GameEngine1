using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YSK_QUETIONBOX : MonoBehaviour
{
    public GameObject emptyBoxPrefab;
    public string includedItemName;
    CHARACTER _mario;
    bool _used = false;

    void Start()
    {
        _mario = FindObjectOfType<CHARACTER>();
        if (_mario == null)
        {
            print("[!] No Mario in this scene");
        }

        if (includedItemName == null)
        {
            print("[!] Empty quetion box");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_used && collision.transform.gameObject == _mario.gameObject && 1 < collision.relativeVelocity.y)
        {
            _used = true;
            OnHeading();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
    }

    void OnHeading()
    {
        //GetComponentsInChildren<GameObject>().ForEach(name => { name.SetActive(false); });
        foreach (var i in GetComponentsInChildren<SkinnedMeshRenderer>()) i.enabled = false;
        Instantiate(emptyBoxPrefab, transform.position, transform.rotation, null);
        StartCoroutine(GenerateItem());
    }

    GameObject _gened_item;
    IEnumerator GenerateItem()
    {
        _gened_item = PoolingManager.H.Get(includedItemName, transform.position, transform.rotation);

        float animateTime = 0.5f;
        float animateLength = transform.lossyScale.y;
        float animateSpeedScalar = animateLength / animateTime;
        float animateSpeedperSec = animateSpeedScalar;

        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            float animateSpeed = animateSpeedperSec * Time.deltaTime;
            _gened_item.transform.position += Vector3.up * animateSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        gameObject.SetActive(false);
    }
}
