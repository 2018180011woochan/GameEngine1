using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAHRACTER_DUST : MonoBehaviour
{
    public ParticleSystem _Particle;
    public CHARACTER _Character;
    int cnt = 0;
    void Update()
    {
        if (_Character.ISGROUND)
        {
            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && cnt < 1)
            {
                _Particle.Play();
            }
            //!> ��ƼŬ�� �����Ӵ����� ���ͼ� ���� ����
            cnt++;
            if (cnt > 10)
                cnt = 0;

            if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
            {
                _Particle.Stop();
            }
        }
       
    }
}
