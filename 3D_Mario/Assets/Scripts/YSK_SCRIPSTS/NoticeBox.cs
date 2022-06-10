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
    Vector3 _targetscale;
    const float _animateScaleRatio = 0.01f;

    private void Awake()
    {
        if (!postTexture) print($"no texture to post");

        _poster = GetComponentsInChildren<Transform>(true).Where(m => { return m.name == "Post"; }).First().gameObject;
        _poster.GetComponent<MeshRenderer>().material.mainTexture = postTexture;
        _poster.SetActive(false);
        _mario = FindObjectOfType<CHARACTER>().gameObject;
        _maincamera = GameObject.FindGameObjectsWithTag("MainCamera").First();

        _targetscale = _poster.transform.localScale;
        _targetscale.x = _poster.transform.localScale.y * postTexture.width / postTexture.height;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_posting && collision.transform.gameObject == _mario && 1 < collision.relativeVelocity.y)
        {
            _posting = true;
            _poster.SetActive(true);
            _poster.transform.LookAt(-_maincamera.transform.position);
            _poster.transform.up = Vector3.up;
            
            _poster.transform.localScale = _targetscale * _animateScaleRatio;
            StartCoroutine(PostEffetct());
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
                StartCoroutine(DisPostEffetct());
            }
        }
    }

    IEnumerator PostEffetct()
    {
        const float animateTime = 0.5f;
        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            _poster.transform.localScale = Vector3.Lerp(_poster.transform.localScale, _targetscale, _interval_time / animateTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator DisPostEffetct()
    {
        const float animateTime = 0.5f;
        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            _poster.transform.localScale = Vector3.Lerp(_poster.transform.localScale, _targetscale * _animateScaleRatio, _interval_time / animateTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _poster.SetActive(false);
    }
}
