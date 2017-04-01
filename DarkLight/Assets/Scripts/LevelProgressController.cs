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
        GameObject.FindGameObjectWithTag("LeftButton").SetActive(false);
        GameObject.FindGameObjectWithTag("RightButton").SetActive(false);
        GameObject.FindGameObjectWithTag("UpButton").SetActive(false);
        StartCoroutine(EnablePlayer());

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

    private IEnumerator EnablePlayer()
    {
        yield return new WaitForSeconds(0.0001f);
        GameObject.Find("ButtonsContainer").transform.FindChild("Left").gameObject.SetActive(true);
        GameObject.Find("ButtonsContainer").transform.FindChild("Right").gameObject.SetActive(true);
        GameObject.Find("ButtonsContainer").transform.FindChild("Up").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AccessToJoyPad();
    }
}
