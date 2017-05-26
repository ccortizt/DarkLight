using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject effect;
    [SerializeField] GameObject firePrefab;

    private bool canGenerateFire = true;
    //private float particleEffectDuration = 1.2f;

    private float energyToDecrease = 2.5f;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player") && canGenerateFire)
        {
            ParticleSystem p = this.gameObject.GetComponent<ParticleSystem>();
            var s = p.shape;
            s.shapeType = ParticleSystemShapeType.Sphere;
            StartCoroutine(FixShape());

            coll.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -10f,0);
            coll.gameObject.GetComponent<PlayerEnergyController>().DecreaseEnergy(energyToDecrease);
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
            GenerateFire();
            canGenerateFire = false;
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
           
            coll.gameObject.GetComponent<PlayerCollisionController>().InstantiateTakenEnergyEffect();            
            Destroy(gameObject);
            coll.gameObject.GetComponent<PlayerEnergyController>().AddEnergy(energyToDecrease * 0.65f);
        }
    }

    private void GenerateFire()
    {
        Debug.Log("GENERATED NEW FIRE");
        float newPosX = ( this.gameObject.transform.position.x >= 0 )? -2.5f : 2.5f;
        var f = (GameObject)Instantiate(firePrefab, new Vector3(gameObject.transform.position.x + newPosX, transform.position.y + 2, 0), transform.rotation);
        f.gameObject.GetComponent<FireMovement>().SetVelocity(gameObject.GetComponent<FireMovement>().GetVelocity());
    }

    public void CanGenerateFire(bool canGenerate){
        canGenerateFire = canGenerate;
    }

}
