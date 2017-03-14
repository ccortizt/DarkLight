using System;
using System.Collections.Generic;
using UnityEngine;
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
            Destroy(gameObject);
        }
    }
}