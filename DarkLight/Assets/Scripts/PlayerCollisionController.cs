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

    void Start()
    {
        staticWallChecked = false;
        dynamicWallChecked = false;
    }
    void Update()
    {
        if (CheckCrushed())
        {
            EndGame("Fuiste Aplastado");
        }
    }
   

    public void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.layer == staticWallLayer)
        {
            if (coll.impulse.x != 0)
            {
                staticWallChecked = true;
            }          

        }

        if (coll.gameObject.layer == dynamicWallLayer)
        {
            if (coll.impulse.x != 0)
            {
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
        return dynamicWallChecked && staticWallChecked;
    }

    public void EndGame(string endGameText)
    {
        GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = endGameText;
        GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
    }
}