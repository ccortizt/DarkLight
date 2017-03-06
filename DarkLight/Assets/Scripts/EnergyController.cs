using System;
using System.Collections.Generic;
using UnityEngine;
public class EnergyController: MonoBehaviour{

    public GameObject effect;
    float energy = 15;

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energy);
            InstantiateTakenEnergyEffect();            
        }
    }

    private void InstantiateTakenEnergyEffect()
    {
        var eff = (GameObject)Instantiate(effect, transform.position, transform.rotation);

        Destroy(eff, 2);
        Destroy(gameObject);
    }
}