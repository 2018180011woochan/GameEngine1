using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YSK_QUETIONBOX : MonoBehaviour
{
    public GameObject emptyBoxPrefab;
    public GameObject includedItemPrefab;
    GameObject _gened_item;
    CHARACTER _mario;
    bool _used = false;

    void Start()
    {
        _mario = FindObjectOfType<CHARACTER>();
        if (_mario == null)
        {
            print("[!] No Mario in this scene");
        }

        if (includedItemPrefab == null)
        {
            print("[!] Empty quetion box");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_used && collision.transform.gameObject == _mario.gameObject && collision.transform.position.y < transform.position.y)
        {
            _used = true;
            OnHeading();
        }
    }

    void OnHeading()
    {
        //GetComponentsInChildren<GameObject>().ForEach(name => { name.SetActive(false); });
        foreach (var i in GetComponentsInChildren<SkinnedMeshRenderer>()) i.enabled = false;
        Instantiate(emptyBoxPrefab, transform.position, transform.rotation, null);
        StartCoroutine(GenerateItem());
    }

    IEnumerator GenerateItem()
    {
        const float animateTime = 1f;
        float animateLength = transform.lossyScale.y;
        float animateSpeedScalar = animateLength / animateTime;
        float animateSpeedperSec = animateSpeedScalar;

        _gened_item = Instantiate(includedItemPrefab, transform.position, transform.rotation, null);

        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            float animateSpeed = animateSpeedperSec * Time.deltaTime;
            _gened_item.transform.position += Vector3.up * animateSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        gameObject.SetActive(false);
    }
}
