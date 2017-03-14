using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelIntro: MonoBehaviour{


    public Image im;
 
    void Start()
    {
        transform.FindChild("Panel/LevelText").gameObject.GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text;

        im = transform.FindChild("Panel").gameObject.GetComponent<Image>();
        im.GetComponent<CanvasRenderer>().SetAlpha(1f);
        im.CrossFadeAlpha(-0.1f, 2f, false);

        transform.FindChild("Panel/LevelText").gameObject.GetComponent<Text>().CrossFadeAlpha(-0.1f, 2.0f, false);
        Destroy(gameObject, 1);
    }
}