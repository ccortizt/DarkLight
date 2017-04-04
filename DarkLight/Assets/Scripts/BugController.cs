
using System.Collections;
using UnityEngine;
public class BugController: MonoBehaviour{

    private float energyDrainAmount = 2.1f;
    private float moveSpeed = 1f;

    void Start()
    {
        if (Random.Range(0, 10) > 5)
            transform.rotation = Quaternion.Euler(0, -90, 0);
        else
            transform.rotation = Quaternion.Euler(0, -270, 0);
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * moveSpeed;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            coll.gameObject.GetComponent<PlayerEnergyController>().DecreaseEnergy(energyDrainAmount);
            coll.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
        }

        if (coll.gameObject.name.Contains("left"))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (coll.gameObject.name.Contains("right"))
        {
            transform.rotation = Quaternion.Euler(0, -270, 0);
        }
    }
}