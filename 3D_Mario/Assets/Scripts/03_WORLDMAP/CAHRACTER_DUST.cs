using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTRO_CAHRACTER_DUST : MonoBehaviour
{
    public ParticleSystem _Particle;
    
    int cnt = 0;
    void Update()
    {

        if (cnt < 1)
        {
            _Particle.Play();
        }
        //!> 파티클이 프레임단위로 나와서 따로 조절
        cnt++;
        if (cnt > 10)
            cnt = 0;

    }
}
