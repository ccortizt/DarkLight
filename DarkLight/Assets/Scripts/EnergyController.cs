using System;
using System.Collections.Generic;
using UnityEngine;
public class EnergyController: MonoBehaviour{

    public GameObject effect;
    float energy = 10;

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

        Destroy(eff, 3);
        Destroy(gameObject);
    }
}