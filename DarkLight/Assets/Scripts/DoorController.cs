using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorController: MonoBehaviour{

     public void OnCollisionEnter(Collision coll){
         
         if (coll.gameObject.tag.Equals("Player"))
         {
             
             GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().LevelUp();
             if (GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLevel() < 16)
                SceneManager.LoadScene(0);
         }
     }
     
}