using System;
using System.Collections.Generic;
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
    }

    public int GetLevel()
    {
        return levelCount;
    }
}
