using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DontDestroy: MonoBehaviour{

    private static bool hudExists;

    void Awake()
    {
        if (!hudExists)
        {
            hudExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "";
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(false);
            Destroy(gameObject);
        }

#if !UNITY_ANDROID
        GameObject.Find("LeftController").SetActive(false);
        GameObject.Find("RightController").SetActive(false);
#endif
    }
}