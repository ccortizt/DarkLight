using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart: MonoBehaviour{
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathController>().SetHUDMessage("");
        Time.timeScale = 1;
    }

    public void RestartAllGame()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelProgressController>().RestartAllGame();

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelDifficultyController>().SetDifficultyProportions(1);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        GameObject.Find("BigMessageCanvas").transform.FindChild("Panel").gameObject.SetActive(false);
    }

}