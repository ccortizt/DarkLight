using System;
using System.Collections.Generic;
using UnityEngine;
public class EnergyController: MonoBehaviour{

    public GameObject effect;
    //private float particleEffectDuration = 1.5f;
    float energy = 15;

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energy);
            coll.gameObject.GetComponent<PlayerCollisionController>().InstantiateTakenEnergyEffect();
            Destroy(gameObject);
                     
        }
    }

}