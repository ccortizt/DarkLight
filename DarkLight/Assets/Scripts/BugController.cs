
using System.Collections;
using UnityEngine;
public class BugController: MonoBehaviour{

    private float energyDefaultDrainAmount = 2.1f;
    private float energyDrainAmount = 2.1f;
    private float moveSpeed = 1f;
    
    private bool canHit;

    private Rigidbody rb;

    void Start()
    {
       
        canHit = true;
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
        if (coll.gameObject.name.Contains("Player"))
        {
            coll.gameObject.GetComponent<PlayerEnergyController>().DecreaseEnergy(energyDrainAmount);          
            coll.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 8f, 0);
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
        }

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

        if (coll.gameObject.name.Contains("Platform"))
        {
            
            if (coll.impulse.x != 0)
            {                               
                //rb.velocity = ((new Vector3(-(rb.velocity.x + 5), Random.Range(-5, 12), 0)) * moveSpeed);
                GetComponent<Rigidbody>().velocity = ((new Vector3(-(5), Random.Range(-5, 12), 0)) * moveSpeed);
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


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name.Contains("Player") && canHit)
        {
            canHit = false;
            transform.Translate(0, 2, 0);
            //Debug.Log("init: "+transform.position);
            Vector3 dif = transform.position - coll.transform.position;
            //Debug.Log("dif "+dif);
          
            dif.x = (dif.x > 0) ? dif.x - 0.6f : dif.x + 0.6f;
            //dif.x = (dif.y > 0) ? dif.y - 0.0005f : dif.y + 0.0005f;
            //transform.position = new Vector3(x,y,0f);
            transform.Translate(-dif.x , -dif.y,0,Space.World);
            //Debug.Log("fin: "+transform.position);

        }
    }

    IEnumerator CanHitAgain()
    {
        yield return new WaitForSeconds(2f);
        canHit = true;
    }
}