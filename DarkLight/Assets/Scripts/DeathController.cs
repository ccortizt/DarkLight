﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{

    private int playerLives;

    private static bool deathControllerExists;

    void Start()
    {
        playerLives = 3 ;
    }

    public void DecreaseLives()
    {
        playerLives--;
    }

    public void ResetLives()
    {
        playerLives = 3;
    }


    public void EndGame(string endGameText)
    {

        string deathMessage = "";        
        
        if (playerLives > 1)
        {
            DecreaseLives();
            
            deathMessage = "Continue: " + playerLives;
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);
            Debug.LogError("MUERTO " + endGameText + " "+playerLives);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false; 
            Time.timeScale = 0;
        }
        else
        {
            deathMessage = "No lives remaining";
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
            StartCoroutine(ShowFullLose());
        }
        
        //Debug.Log("MUERTO, VIDAS RESTANTES :" + playerLives);
        SetHUDMessage(endGameText + " " + deathMessage);
        
        
    }
    
    private IEnumerator ShowFullLose()
    {
        yield return new WaitForSeconds(2);
        SetHUDMessage("");
        ResetLives();
        GetComponent<LevelProgressController>().SetLevelOne();
        GetComponent<LevelDifficultyController>().SetDifficultyNotStart();
        GameObject.Find("BigMessageCanvas").transform.FindChild("Panel").gameObject.SetActive(true);
        
    }

    public void SetHUDMessage(string message)
    {
        GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = message;
    }
}
