using System.Collections;
using UnityEngine;

public class ArrowCollisionController : MonoBehaviour
{

    public GameObject effect;
    private float particleEffectDuration = 1.2f;

    float energyToDecrease = 1.5f;
    float energyToIncrease = 0.6f;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            InstantiateTakenEnergyEffect();

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

    private void InstantiateTakenEnergyEffect()
    {
        var eff = (GameObject)Instantiate(effect, transform.position, Quaternion.Euler(-90, 0, 0));

        Destroy(eff, particleEffectDuration);

    }
}
