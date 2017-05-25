using System.Collections;
using UnityEngine;

public class ArrowCollisionController : MonoBehaviour
{

    public GameObject effect;
    //private float particleEffectDuration = 1.2f;

    float energyToDecrease = 1.5f;
    float energyToIncrease = 0.6f;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            coll.gameObject.GetComponent<PlayerCollisionController>().InstantiateTakenEnergyEffect();

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
