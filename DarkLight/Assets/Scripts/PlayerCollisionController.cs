using System;
using System.Collections.Generic;
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
            EndGame("Fuiste Aplastado");
            //Debug.Log("APLASTADO");
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
        string continuar = "";
        GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().ChangeLives(-1);
        Debug.Log(GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLives()+ " VIDAS");
        if(GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLives() <= 0){
            GameObject.Find("BigMessageCanvas").transform.FindChild("Panel").gameObject.SetActive(true);            
        }
        else
        {
            continuar = "Continuar x " + GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLives();
        }
        GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = endGameText +" "+continuar  ;
        GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
    }
}