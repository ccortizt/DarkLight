
using System.Collections;
using UnityEngine;
public class BugController: MonoBehaviour{

    private float energyDefaultDrainAmount = 2.1f;
    private float energyDrainAmount = 2.1f;
    private float moveSpeed = 0.8f;
    
    private Rigidbody rb;

    public bool debugEnabled;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();

        if (Random.Range(0, 10) > 5)
            transform.rotation = Quaternion.Euler(0, -90, 0);
        else
            transform.rotation = Quaternion.Euler(0, -270, 0);

        StartCoroutine(RandomJump());
    }

    void Update()
    {
        rb.velocity = ((-transform.forward + new Vector3(0, GetComponent<Rigidbody>().velocity.y * 0.85f, 0)) * moveSpeed);   
    }

    public void SetVelocity(float vel)
    {
        moveSpeed = vel;
    }

    public void SetEnergyDrain(float energyPercentage)
    {
        energyDrainAmount = energyDefaultDrainAmount + energyDefaultDrainAmount * energyPercentage;
    }

    public float GetEnergyDrain()
    {
        return energyDrainAmount;
    }
    
    private IEnumerator RandomJump()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(3);
            if (Random.Range(0, 10) > 6.5f)
            {
                rb.velocity = ((new Vector3(Random.Range(3, 6), Random.Range(6, 10), 0)) * moveSpeed);
            }
        }
            
    }
    void OnCollisionEnter(Collision coll)
    {
             
        if (coll.gameObject.name.Contains("left"))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rb.velocity = new Vector3(5f, GetComponent<Rigidbody>().velocity.y, 0);
        }

        if (coll.gameObject.name.Contains("right"))
        {
            transform.rotation = Quaternion.Euler(0, -270, 0);
            rb.velocity = new Vector3(-5f, GetComponent<Rigidbody>().velocity.y, 0);
        }

        if (coll.impulse == Vector3.zero)
        {
            GetComponent<Rigidbody>().velocity = (new Vector3(Random.Range(-5, 5), Random.Range(-5, 12), 0) * moveSpeed);
        }

        if (coll.gameObject.name.Contains("Platform"))
        {
            if (debugEnabled)
            {
                Debug.Log(coll.impulse + gameObject.name);
            }

            
            if (coll.impulse.x != 0)
            {
                if (debugEnabled)
                    Debug.Log("1"+coll.impulse + gameObject.name);
                
                GetComponent<Rigidbody>().velocity = ((new Vector3(-(5), Random.Range(-5, 12), 0)) * moveSpeed);
                
                if (debugEnabled)
                    Debug.Log("2"+coll.impulse + gameObject.name);
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
            rb.velocity = ((new Vector3(Random.Range(-8, 8), Random.Range(-6, 10), 0)) * moveSpeed);
        }

        if (coll.gameObject.name.Contains("PlatformDestroy"))
        {
            Destroy(gameObject);
        }
    }

}