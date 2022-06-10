using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class CameraTarget
{
    public Transform Target;
    public float Weight;
    public float Radius;
}

public class YSK_CameraFocusZone : MonoBehaviour
{
    public Cinemachine.CinemachineTargetGroup TargetGroup;
    public Cinemachine.CinemachineVirtualCamera Camera;
    public CameraTarget[] Targets;
    public Vector3 ToOffsetMultiplier;
    public bool AutoFocuingOnTargets = true;
    private Vector3 _TargetPos;
    private Vector3 _OriginOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (!TargetGroup)
            print("NoTargetGroup");

        _TargetPos = new Vector3();

        foreach (var t in Targets)
            _TargetPos += t.Target.position;

        _TargetPos /= Targets.Length;
        var offset = Camera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset;
        _OriginOffset = new Vector3(offset.x, offset.y, offset.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (AutoFocuingOnTargets)
        {

            var offset = Camera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset;
            var q = Quaternion.FromToRotation(offset - _OriginOffset + Vector3.forward, _TargetPos - other.gameObject.transform.position);
            var x = q * _OriginOffset;
            Camera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset = x;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CHARACTER>())
        {
            foreach (var t in Targets)
            {
                TargetGroup.AddMember(t.Target, t.Weight, t.Radius);
            }
        }

        if (ToOffsetMultiplier != Vector3.zero)
        {
            Camera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset.Scale(ToOffsetMultiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CHARACTER>())
        {
            foreach (var t in Targets)
                TargetGroup.RemoveMember(t.Target);

        }

        Camera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>().m_FollowOffset = _OriginOffset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
