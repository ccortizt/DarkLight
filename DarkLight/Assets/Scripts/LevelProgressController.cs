using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LevelProgressController: MonoBehaviour{

    private int levelCount;
    private static bool levelProgressExists;

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
        if (levelCount < 15)
        {
            this.levelCount++;
            UpdateLevelIndicator();
        }
        else
        {
            this.levelCount++;
            GameObject.Find("BigMessageCanvas").transform.FindChild("Panel").gameObject.SetActive(true);    
            GameObject.Find("BigMessageCanvas").transform.FindChild("Panel/VictoryText").gameObject.SetActive(true);
            GameObject.Find("BigMessageCanvas").transform.FindChild("Panel/DefeatText").gameObject.SetActive(false);
        }        

    }

    public void RestartAllGame()
    {
        this.levelCount = 1;
        UpdateLevelIndicator();
        GetComponent<DeathController>().ResetLives();
    }

    private void UpdateLevelIndicator()
    {
        GetComponent<LevelDifficultyController>().SetDifficultyProportions(levelCount);
        GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text = "Lvl. " + levelCount;        
    }

    public int GetLevel()
    {
        return levelCount;
    }

    
}
