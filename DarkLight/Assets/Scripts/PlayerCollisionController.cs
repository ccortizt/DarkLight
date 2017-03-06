using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionController: MonoBehaviour{


    string punishmentMesagge = "No parece ser buena idea intentar cruzar los muros externos";
    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Equals("DarkGround"))
        {
            GetComponent<DarkPlayerController>().PunishmentEnergyConsumption();
            GameObject.Find("PlayerHUD").transform.FindChild("VisionPanel/Text").gameObject.GetComponent<Text>().text = punishmentMesagge;
            //bad idea
        }

       
       
    }
}