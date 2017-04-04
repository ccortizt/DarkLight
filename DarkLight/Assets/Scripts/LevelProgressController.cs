using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LevelProgressController: MonoBehaviour{

    private int levelCount;
    private static bool levelProgressExists;
    private int playerContinues = 3;

    void Awake()
    {
        if (!levelProgressExists)
        {
            levelProgressExists = true;
            DontDestroyOnLoad(transform.gameObject);
            levelCount = 1;
            UpdateLevelIndicator();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "";
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(false);
            Destroy(gameObject);
        }   
    }


    public void LevelUp()
    {
        if (levelCount <= 15)
        {
            this.levelCount++;
            UpdateLevelIndicator();
        }
        else
        {
            GameObject.Find("BigMessageCanvas").SetActive(true);
            GameObject.Find("BigMessageCanvas").transform.FindChild("Panel/VictoryText").gameObject.SetActive(true);
            GameObject.Find("BigMessageCanvas").transform.FindChild("Panel/DefeatText").gameObject.SetActive(false);
        }
        

    }

    public void RestartAllGame()
    {
        this.levelCount = 1;
        UpdateLevelIndicator();
        playerContinues = 3;
    }

    public void ChangeLives(int lives)
    {
        playerContinues = playerContinues + lives;
    }

    public int GetLives()
    {
        return playerContinues;
    }

    private void UpdateLevelIndicator()
    {
        GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text = "Lv. " + levelCount;
        GetComponent<LevelDifficultyController>().SetDifficultyProportions(levelCount);
    }

    public int GetLevel()
    {
        return levelCount;
    }

    
}
