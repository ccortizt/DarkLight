using System;
using System.Collections.Generic;
using UnityEngine;
public class VFXController: MonoBehaviour{
    public void PlayEffect()
    {
        GetComponent<ParticleSystem>().Play();
    }
}