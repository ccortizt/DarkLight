using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionController: MonoBehaviour{


    public bool playerIsCrushed;

    private bool staticWallChecked;
    private bool dynamicWallChecked;

    void Start()
    {
        staticWallChecked = false;
        dynamicWallChecked = false;
    }
    void Update()
    {
        if (CheckCrushed())
        {
            GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "Aplastado!";
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);// = true;
            GetComponent<PlayerController>().enabled = false;
        }
    }
   

    public void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.layer==10)
        {
            if (coll.impulse.x != 0)
            {
                staticWallChecked = true;
            }          

            //Debug.Log("wall" + coll.impulse);
        }

        if (coll.gameObject.layer == 9)
        {
            if (coll.impulse.x != 0)
            {
                dynamicWallChecked = true;
            }
            
            //Debug.Log("dynamicwall"+ coll.impulse);
        }

    }

    void OnCollisionExit(Collision coll)
    {
        
        if (coll.gameObject.layer == 10)
        {
            //Debug.Log("notwall");
            staticWallChecked = false;
        }

        if (coll.gameObject.layer == 9)
        {
            //Debug.Log("notdynamicwall");
            dynamicWallChecked = false;
        }

    }


    public bool CheckCrushed(){
        return dynamicWallChecked && staticWallChecked;
    }
}