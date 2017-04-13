
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionController: MonoBehaviour{

    
    public bool playerIsCrushed;

    private bool staticWallChecked;

    private bool dynamicWallChecked;

    private int dynamicWallLayer = 9;
    private int staticWallLayer = 10;
    private int staticGroundLayer = 8;

    private float energyPercentageIncrease = 0.4f;

    float timeStaying;

    private bool dontCheck;

    void Start()
    {
        timeStaying = 0 ;
        dontCheck = false;
        staticWallChecked = false;
        dynamicWallChecked = false;
    }
    void Update()
    {
        if (CheckCrushed())
        {
            dontCheck = true;
            GameObject.FindGameObjectWithTag("Damage").GetComponent<FlashFade>().Flash();
            EndGame("Fuiste Aplastado");
            
        }
    }
   

    public void OnCollisionStay(Collision coll)
    {

        if (coll.gameObject.layer == staticWallLayer || coll.gameObject.layer == staticGroundLayer)
        {
            
            if (coll.impulse.x != 0)
            {
                Debug.Log(coll.impulse+ " s");
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
                
            }

            timeStaying += Time.deltaTime;           
            
        }

        if (timeStaying > 6f && coll.impulse != Vector3.zero && dynamicWallChecked)
        {
            EndGame("Fuiste Aplastado");
        }

    }

    void OnCollisionExit(Collision coll)
    {

        if (coll.gameObject.layer == staticWallLayer || coll.gameObject.layer == staticGroundLayer)
        {   
            staticWallChecked = false;
            timeStaying = 0 ;
        }

        if (coll.gameObject.layer == dynamicWallLayer)
        {
            dynamicWallChecked = false;
            timeStaying = 0;
        }

    }


    public bool CheckCrushed(){
        if (!dontCheck)
            return dynamicWallChecked && staticWallChecked;
        else
            return false;
    }

    public void EndGame(string endGameText)
    {
        //canDie = false;
        string continuar = "";       
        
        if(GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLives() <= 1){
            continuar = "Sin vidas restantes";       
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = endGameText + " " + continuar;
            
            StartCoroutine(ShowFullLose());            
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Restart").GetComponent<Restart>().canDie)
            {
                GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().ChangeLives(-1);
                continuar = "Continuar x " + GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLives();
                GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Restart").GetComponent<Restart>().SetCanDie(false);
            }            

        }
        GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = endGameText +" "+continuar  ;
        
        GetComponent<PlayerController>().enabled = false;
        StartCoroutine(TurnLightOff());
        
    }

    private IEnumerator ShowFullLose()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "";
        GameObject.Find("BigMessageCanvas").transform.FindChild("Panel").gameObject.SetActive(true);            
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
            Destroy(coll.gameObject);
            GetComponent<PlayerEnergyController>().AddEnergy(coll.gameObject.GetComponent<BugController>().GetEnergyDrain() * energyPercentageIncrease);
        }
    }
   IEnumerator TurnLightOff(){
       yield return new WaitForSeconds(3);
       transform.FindChild("LightObject").gameObject.GetComponent<Light>().enabled = false;
   }
    
}