using System.Collections;
using UnityEngine;
public class ColorController: MonoBehaviour{
    
    [SerializeField]
    Material ambientColor;

    [SerializeField]
    Material trailMaterial;

    private int currentH;
    private float auxH;
    void Start()
    {
        GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLevel();
        currentH = Random.Range(0,360);
        auxH = (float)currentH / (float)360;
        ModifyMaterial(auxH, 0.5f);
        
    }

    void FixedUpdate()
    {
        UpdateMaterialSaturation();
    }

    private void UpdateMaterialSaturation()
    {
        ModifyMaterial(auxH, Mathf.PingPong(Time.time, 7));
    }

    public void ModifyMaterial(float h, float s)
    {
        Color test = ambientColor.color;
        test = Color.HSVToRGB(h, s, 0.5f);
        ambientColor.SetColor("_Color", test);

        //For Trail
        float emission = Mathf.PingPong(Time.time, 1.0f);        
        Color finalColor = test * Mathf.LinearToGammaSpace(emission);
        trailMaterial.SetColor("_EmissionColor", finalColor);
       
        
    }

}