using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHUDManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text = "Lvl. " +
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelProgressController>().GetLevel();
    }


}
