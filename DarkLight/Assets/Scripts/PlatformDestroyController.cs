using System;
using System.Collections.Generic;
using UnityEngine;
public class PlatformDestroyController: MonoBehaviour{

    public bool positiveSide;

    private float defaultProportion = 0.02f;
    private float proportion;

    private bool stop;
    void Start()
    {
        proportion = defaultProportion;
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
        if (transform.position.x >= -0.001 && transform.position.x <= 0.001)
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

    public void SetProportion(float p)
    {
        proportion += proportion * p;
    }
}