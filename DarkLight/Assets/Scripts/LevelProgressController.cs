using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelProgressController: MonoBehaviour{

    public int levelCount;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        levelCount = 1;
        UpdateLevelIndicator();
    }

    public void LevelUp()
    {
        levelCount++;
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
