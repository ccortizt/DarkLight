using System.Collections;
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
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;        

        if (playerLives > 1)
        {
            DecreaseLives();
            deathMessage = "Continuar: " + playerLives;
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            deathMessage = "Sin vidas restantes";
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(false);           

            StartCoroutine(ShowFullLose());
        }
        
        //Debug.Log("MUERTO, VIDAS RESTANTES :" + playerLives);
        SetHUDMessage(endGameText + " " + deathMessage);
        
        
    }
    
    private IEnumerator ShowFullLose()
    {
        yield return new WaitForSeconds(2);
        SetHUDMessage("");
        GameObject.Find("BigMessageCanvas").transform.FindChild("Panel").gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetHUDMessage(string message)
    {
        GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = message;
    }
}
