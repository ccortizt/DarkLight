using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidUI : MonoBehaviour
{

    void Awake()
    {
#if !UNITY_ANDROID
        GameObject.Find("LeftController").SetActive(false);
        GameObject.Find("RightController").SetActive(false);
        GameObject.Find("AuxControllerPanel1").SetActive(false);
        GameObject.Find("AuxControllerPanel2").SetActive(false);
#endif

    }

   
}
