
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionController : MonoBehaviour
{
    public GameObject effect;
    private float particleEffectDuration = 1.2f;

    public bool playerIsCrushed;

    private bool staticWallChecked;

    private bool dynamicWallChecked;

    private int dynamicWallLayer = 9;
    private int staticWallLayer = 10;
    private int staticGroundLayer = 8;

    private float energyPercentageIncrease = 0.65f;

    float timeStaying;

    private bool dontCheck;

    GameObject gameManager;

    GameObject currentCrushWall;

    void Start()
    {
        timeStaying = 0;
        dontCheck = false;
        staticWallChecked = false;
        dynamicWallChecked = false;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    void Update()
    {
        if (CheckCrushed())
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            dontCheck = true;
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
            
            if (currentCrushWall != null)
            {
                currentCrushWall.GetComponent<PlatformDestroyController>().enabled = false;
            }

            gameManager.GetComponent<DeathController>().EndGame("Fuiste Aplastado");

            //StartCoroutine(TurnLightOff());            
        }
    }


    public void OnCollisionStay(Collision coll)
    {

        if (coll.gameObject.layer == staticWallLayer || coll.gameObject.layer == staticGroundLayer)
        {

            if (coll.impulse.x != 0)
            {
                //Debug.Log(coll.impulse+ " s");
                staticWallChecked = true;
                timeStaying += Time.deltaTime;
            }

        }

        if (coll.gameObject.layer == dynamicWallLayer)
        {
            if (coll.impulse.x != 0)
            {
                //Debug.Log(coll.impulse+ " d");
                dynamicWallChecked = true;
                currentCrushWall = coll.gameObject;
            }

            timeStaying += Time.deltaTime;

        }

        if (timeStaying > 6f && coll.impulse != Vector3.zero && dynamicWallChecked)
        {
            gameManager.GetComponent<DeathController>().EndGame("Fuiste Aplastado");
            //StartCoroutine(TurnLightOff());
        }

    }

    void OnCollisionExit(Collision coll)
    {

        if (coll.gameObject.layer == staticWallLayer || coll.gameObject.layer == staticGroundLayer)
        {
            staticWallChecked = false;
            timeStaying = 0;
        }

        if (coll.gameObject.layer == dynamicWallLayer)
        {
            dynamicWallChecked = false;
            currentCrushWall = null;
            timeStaying = 0;
        }

    }

    public bool CheckCrushed()
    {
        if (!dontCheck)
            return dynamicWallChecked && staticWallChecked;
        else
            return false;
    }


    IEnumerator TurnLightOff()
    {
        yield return new WaitForSeconds(.8f);
        transform.FindChild("LightObject").gameObject.GetComponent<Light>().enabled = false;
    }


    void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.gameObject.name.Contains("Bug"))
        {
            GetComponent<PlayerEnergyController>().DecreaseEnergy(coll.gameObject.GetComponent<BugController>().GetEnergyDrain());
            GetComponent<Rigidbody>().velocity = new Vector3(0, 8f, 0);
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
        }
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.name.Contains("Bug"))
        {
            GetComponent<PlayerEnergyController>().AddEnergy(coll.gameObject.GetComponent<BugController>().GetEnergyDrain() * energyPercentageIncrease);
            
            InstantiateTakenEnergyEffect();

            Destroy(coll.gameObject);
        }
    }

    private void InstantiateTakenEnergyEffect()
    {
        var eff = (GameObject)Instantiate(effect, transform.position, Quaternion.Euler(-90, 0, 0));

        Destroy(eff, particleEffectDuration);
        
    }

}