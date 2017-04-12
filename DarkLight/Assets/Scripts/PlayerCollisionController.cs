
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionController: MonoBehaviour{

    
    public bool playerIsCrushed;

    private bool staticWallChecked;
    private bool dynamicWallChecked;

    private int dynamicWallLayer = 9;
    private int staticWallLayer = 10;

    private bool dontCheck;

    void Start()
    {
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
        if (coll.gameObject.layer == staticWallLayer)
        {
            if (coll.impulse.x != 0)
            {
                //Debug.Log(coll.impulse+ " s");
                staticWallChecked = true;
            }          

        }

        if (coll.gameObject.layer == dynamicWallLayer)
        {
            if (coll.impulse.x != 0)
            {
                //Debug.Log(coll.impulse+ " d");
                dynamicWallChecked = true;
            }
            
        }

    }

    void OnCollisionExit(Collision coll)
    {
        
        if (coll.gameObject.layer == staticWallLayer)
        {   
            staticWallChecked = false;
        }

        if (coll.gameObject.layer == dynamicWallLayer)
        {
            dynamicWallChecked = false;
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
        string continuar = "Sin vidas restantes";       
        
        if(GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLives() <= 1){
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
        }
    }
   
}