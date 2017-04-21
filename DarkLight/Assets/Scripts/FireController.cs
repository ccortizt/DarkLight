using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject effect;
    private float particleEffectDuration = 1.2f;

    private float energyToDecrease = 2.5f;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            ParticleSystem p = this.gameObject.GetComponent<ParticleSystem>();
            var s = p.shape;
            s.shapeType = ParticleSystemShapeType.Sphere;
            StartCoroutine(FixShape());

            coll.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -10f,0);
            coll.gameObject.GetComponent<PlayerEnergyController>().DecreaseEnergy(energyToDecrease);
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
        }
    }

    IEnumerator FixShape()
    {
        yield return new WaitForSeconds(5);
        ParticleSystem p = this.gameObject.GetComponent<ParticleSystem>();
        var s = p.shape;
        s.shapeType = ParticleSystemShapeType.Cone; 
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            InstantiateTakenEnergyEffect();
            Destroy(gameObject);
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energyToDecrease * 0.65f);
        }
    }

    private void InstantiateTakenEnergyEffect()
    {
        var eff = (GameObject)Instantiate(effect, transform.position, Quaternion.Euler(-90, 0, 0));

        Destroy(eff, particleEffectDuration);

    }
}
