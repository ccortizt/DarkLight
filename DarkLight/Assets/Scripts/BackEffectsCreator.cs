using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEffectsCreator : MonoBehaviour
{
    public GameObject prefabEffect;
    
    void Start()
    {
        AddEffects();
    }

    private void AddEffects()
    {
        int min = 2;
        for (int i = 0; i < 8; i++)
        {
            var ef = (GameObject)Instantiate(prefabEffect, new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(min,50), 5), transform.rotation);
            min += 8;
            float size = Random.Range(.01f,.05f);
            ef.transform.localScale += new Vector3(size,0,size);
        }        
    }

}
