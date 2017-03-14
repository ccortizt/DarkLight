using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorController: MonoBehaviour{

     public void OnCollisionEnter(Collision coll){
         
         if (coll.gameObject.tag.Equals("Player"))
         {
             Debug.Log("player up");
             GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().LevelUp();
             //transition nedeed
             SceneManager.LoadScene(0);
         }
     }
     
}