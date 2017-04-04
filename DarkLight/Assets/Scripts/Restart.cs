using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart: MonoBehaviour{

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartAllGame()
    {
        GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().RestartAllGame();
        SceneManager.LoadScene(0);

    }
}