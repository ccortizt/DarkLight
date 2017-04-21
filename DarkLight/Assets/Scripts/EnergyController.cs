using System;
using System.Collections.Generic;
using UnityEngine;
public class EnergyController: MonoBehaviour{

    public GameObject effect;
    private float particleEffectDuration = 1.5f;
    float energy = 15;

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energy);
            InstantiateTakenEnergyEffect();            
        }
    }

    private void InstantiateTakenEnergyEffect()
    {
        var eff = (GameObject)Instantiate(effect, transform.position, Quaternion.Euler(-90,0,0));

        Destroy(eff, particleEffectDuration);
        Destroy(gameObject);
    }
}