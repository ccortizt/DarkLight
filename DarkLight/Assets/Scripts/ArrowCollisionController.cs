
using System.Collections;
using UnityEngine;

public class ArrowCollisionController : MonoBehaviour {


    float energyToDecrease = 1.5f;
    float energyToIncrease = 0.6f;
    

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            Destroy(gameObject);
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energyToIncrease);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
            coll.gameObject.GetComponent<PlayerEnergyController>().DecreaseEnergy(energyToDecrease);
            Destroy(gameObject);
        }
    }
}
