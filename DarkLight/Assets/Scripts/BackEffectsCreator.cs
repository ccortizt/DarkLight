using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEffectsCreator : MonoBehaviour
{
    public GameObject prefabEffect;
    [SerializeField] Color[] baseColor;
    
    void Start()
    {
        AddEffects();
    }

    private void AddEffects()
    {
        float min = 4;
        float max = 8;
        for (int i = 0; i < 8; i++)
        {
            var ef = (GameObject)Instantiate(prefabEffect, new Vector3(Random.Range(-3.8f, 3.8f), Random.Range(min,max), 5), transform.rotation);
            min += 4;
            max += 4.5f;
            float size = Random.Range(.01f,.05f);
            ef.transform.localScale += new Vector3(size,0,size);
            ParticleSystem.MainModule settings = ef.gameObject.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(baseColor[i]);
            
        }        
    }

}
