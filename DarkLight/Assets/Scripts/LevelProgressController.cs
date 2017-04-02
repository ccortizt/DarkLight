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
        this.levelCount++;
        UpdateLevelIndicator();

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
