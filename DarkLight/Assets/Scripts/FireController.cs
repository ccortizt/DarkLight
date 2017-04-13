using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    private float energyToDecrease = 3f;

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
            Destroy(gameObject);
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energyToDecrease * 0.4f);
        }
    }
}
