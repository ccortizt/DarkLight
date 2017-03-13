using System;
using System.Collections.Generic;
using UnityEngine;
public class PlatformDestroyController: MonoBehaviour{

    public bool positiveSide;

    private float proportion = 0.02f;

    private bool stop;
    void Start()
    {
        stop = false;
        if (transform.position.x > 0)
        {
            positiveSide = true;
        }
        else
        {
            positiveSide = false;
        }
    }

    void Update()
    {

        if (!stop)
        {
            CheckStop();
            MoveAndDestroy();
        }            
        
    }

    private void CheckStop()
    {
        if (transform.position.x >= -0.005 && transform.position.x <= 0.005)
        {
            stop = true;
        }
    }

    void MoveAndDestroy()
    {
        if (positiveSide)
        {
            transform.position += new Vector3(-proportion, 0, 0);
        }

        else
        {
            transform.position += new Vector3(proportion, 0, 0);
        }
    }
}