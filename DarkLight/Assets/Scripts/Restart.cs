using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart: MonoBehaviour{


    public bool canDie;

    void Start()
    {
        canDie = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        canDie = true;
    }

    public void RestartAllGame()
    {
        GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().RestartAllGame();
        SceneManager.LoadScene(0);

    }

    public void SetCanDie(bool can)
    {
        canDie = can;
    }
}