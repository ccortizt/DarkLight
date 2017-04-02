using System.Collections;
using UnityEngine;
public class ColorController: MonoBehaviour{
    
    public Material mat;
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
        Color test = mat.color;
        test = Color.HSVToRGB(h, s, 0.5f);
        mat.SetColor("_Color", test);
    }

}