using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Goal : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart _cart;
    private Cinemachine.CinemachineSmoothPath _track;
    private Cinemachine.CinemachineVirtualCamera _camera;
    private void Start()
    {
        _cart = GetComponentInChildren<Cinemachine.CinemachineDollyCart>();
        _cart.gameObject.SetActive(false);
        _camera = GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
        _camera.Priority = 0;
        _track = GetComponentInChildren<Cinemachine.CinemachineSmoothPath>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _camera.Priority = 50;
            other.gameObject.GetComponent<CHARACTER>().ReadyAnimate();
            StartCoroutine(StartCameraMove());
        }
    }

    IEnumerator StartCameraMove()
    {
        const float animateTime = 1.0f;
        _cart.gameObject.SetActive(true);
        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _cart.m_Speed = _track.PathLength / animateTime;
        for (float _interval_time = 0f; _interval_time <= animateTime; _interval_time += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _cart.gameObject.SetActive(false);
        
        _camera.Priority = 0;
        WORLDMAP_UI.H.FadeStart(); 
        LOAD_MNG.LoadScene("02_WORLDMAP");
    }
}
