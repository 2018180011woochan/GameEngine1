using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Search;

public class YSK_PIPE_HOLE_SCRIPT : MonoBehaviour
{
    public YSK_PIPE_HOLE_SCRIPT jointed_pipe;
    CHARACTER _mario;
    Vector3 _hole_position;
    const float diffy = 0.8f; // 마리오랑 피봇 차이 때문에 필요함.
    public void Awake()
    {
        _mario = FindObjectOfType<CHARACTER>();
        _hole_position = transform.position;
        _hole_position.y -= diffy;
        if (_mario == null)
        {
            print("[!] No Mario in this scene");
        }

        if (jointed_pipe == null)
        {
            print("[!] jointed_pipe is null");
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CHARACTER>() == _mario)
            OnCollidePipeHole();
    }

    void OnCollidePipeHole()
    {
        
        if (_mario.GET_ACTIONKEY_ON())
        {
            OnEnter();
        }
    }
    void OnEnter()
    {
        _mario.OnPipeEnter(this);
    }

    public void PassedOut()
    {
        jointed_pipe.OnExit();
    }

    void OnExit()
    {
        _mario.OnPipeExit(this);
    }

    public Vector3 GetHolePositionOutside()
    {
        return _hole_position + transform.up * diffy;
    }

    public Vector3 GetHolePositionInside()
    {
        return _hole_position - transform.up * (3f - diffy);
    }
}
