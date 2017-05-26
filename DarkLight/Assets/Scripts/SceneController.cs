using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{

    public void GoToMainMenu()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathController>().ResetLives();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelProgressController>().SetLevelOne();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelDifficultyController>().SetDifficultyNotStart();
        SceneManager.LoadScene(0);
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
}
