
using System.Collections;
using UnityEngine;
public class BugController: MonoBehaviour{

    private float energyDefaultDrainAmount = 2.1f;
    private float energyDrainAmount = 2.1f;
    private float moveSpeed = 1f;

    void Start()
    {
        if (Random.Range(0, 10) > 5)
            transform.rotation = Quaternion.Euler(0, -90, 0);
        else
            transform.rotation = Quaternion.Euler(0, -270, 0);

        StartCoroutine(RandomJump());
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = ((-transform.forward + new Vector3(0, GetComponent<Rigidbody>().velocity.y * 0.85f, 0)) * moveSpeed);   
    }

    public void SetVelocity(float vel)
    {
        moveSpeed = vel;
    }

    public void SetEnergyDrain(float energyPercentage)
    {
        energyDrainAmount = energyDefaultDrainAmount + energyDefaultDrainAmount * energyPercentage;
    }


    private IEnumerator RandomJump()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(3);
            if (Random.Range(0, 10) > 6.5f)
            {
                GetComponent<Rigidbody>().velocity = ((new Vector3(Random.Range(3, 6), Random.Range(6, 10), 0)) * moveSpeed);
            }
        }
            
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player"))
        {
            coll.gameObject.GetComponent<PlayerEnergyController>().DecreaseEnergy(energyDrainAmount);          
            coll.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 8f, 0);
          
        }

        if (coll.gameObject.name.Contains("left"))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(5f, GetComponent<Rigidbody>().velocity.y, 0);
        }

        if (coll.gameObject.name.Contains("right"))
        {
            transform.rotation = Quaternion.Euler(0, -270, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(-5f, GetComponent<Rigidbody>().velocity.y, 0);
        }

        if (coll.gameObject.name.Contains("Platform"))
        {
            Debug.Log(coll.impulse);
            if (coll.impulse.x != 0)
            {                               
                //GetComponent<Rigidbody>().velocity = ((new Vector3(Random.Range(3, 6), Random.Range(6, 10), 0)) * moveSpeed);
                GetComponent<Rigidbody>().velocity = ((new Vector3(-(GetComponent<Rigidbody>().velocity.x + 5), Random.Range(-5, 12), 0)) * moveSpeed);
            }

            if (coll.impulse.x > 0 && coll.impulse.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (coll.impulse.x < 0 && coll.impulse.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, -270, 0);
            }

        }

        if (coll.gameObject.name.Contains("Bug")){
            if (coll.impulse.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -270, 0);
            }
            GetComponent<Rigidbody>().velocity = ((new Vector3(Random.Range(-8, 8), Random.Range(-6, 10), 0)) * moveSpeed);
        }

        if (coll.gameObject.name.Contains("PlatformDestroy"))
        {
            Destroy(gameObject);
        }
    }
}