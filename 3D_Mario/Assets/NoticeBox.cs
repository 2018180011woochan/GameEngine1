using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Search;

public class NoticeBox : MonoBehaviour
{
    public Texture2D postTexture;
    public float disableDiff;

    bool _posting = false;
    GameObject _poster;
    GameObject _mario;
    GameObject _maincamera;

    private void Awake()
    {
        _poster = GetComponentsInChildren<Transform>(true).Where(m => { print(m.name); return m.name == "Post"; }).First().gameObject;
        _poster.GetComponent<MeshRenderer>().material.mainTexture = postTexture;
        _poster.SetActive(false);
        _mario = FindObjectOfType<CHARACTER>().gameObject;
        _maincamera = GameObject.FindGameObjectsWithTag("MainCamera").First();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_posting)
        {
            _posting = true;
            _poster.SetActive(true);
            _poster.transform.LookAt(-_maincamera.transform.position);
            _poster.transform.up = Vector3.up;
        }
    }

    void Update()
    {
        if (_posting)
        {
            var diff = _mario.transform.position - transform.position;
            if (disableDiff < diff.magnitude)
            {
                _posting = false;
                _poster.SetActive(false);
            }
        }
    }

    IEnumerator PostEffetct()
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
