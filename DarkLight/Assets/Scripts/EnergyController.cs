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
        var eff = (GameObject)Instantiate(effect, transform.position, transform.rotation);

        Destroy(eff, 3);
        Destroy(gameObject);
    }
}