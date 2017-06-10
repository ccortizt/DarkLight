using System.Collections;
using UnityEngine;
public class PlatformController: MonoBehaviour{

    private bool isStable;
    private float stabilityTime = 2.5f;
    public Material mat;
    
    float yPosPlus = 0;
    float yPosMinus = 0;

    void Start()
    {
        SetStability(SetProbability(GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLevel()));
        //StartCoroutine(WaitMovement());
    }

    void Update()
    {
        yPosPlus = Random.Range(0.1f,0.25f);
        yPosMinus = Random.Range(0.1f,0.25f);


        if(Mathf.Round(Time.time) % 2 == 0 )
            transform.position = Vector3.Lerp(transform.position, transform.position - new Vector3(0,yPosMinus,0), 0.015f);
        if (Mathf.Round(Time.time) % 2 == 1)
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, yPosPlus, 0), 0.015f);
       
    }

    private IEnumerator WaitMovement()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.position = transform.position += new Vector3(0, yPosPlus, 0);
            yield return new WaitForSeconds(1);
            transform.position = transform.position -= new Vector3(0, yPosMinus, 0);
        }        
    }

    private void SetStability(float prob)
    {
        if (Random.Range(0, 100) > prob)
        {
            isStable = false;
        }
        else
        {
            isStable = true;
        }
    }

    private float SetProbability(int lvl)
    {
        if (lvl < 3)
        {
            stabilityTime = 2.5f;
            return 97;
        }

        if (lvl >= 3 && lvl < 5)
        {
            stabilityTime = 2.2f;
            return 86;
        }

        if (lvl >= 5 && lvl < 7)
        {
            stabilityTime = 2f;
            return 74;
        }

        if (lvl >= 7 && lvl < 10)
        {
            stabilityTime = 1.7f;
            return 66;
        }

        if (lvl >= 10 && lvl < 12)
        {
            stabilityTime = 1.2f;
            return 52;
        }

        if (lvl >= 12 && lvl < 13)
        {
            stabilityTime = 0.8f;
            return 38;
        }
        if (lvl >= 13 && lvl < 14)
        {
            stabilityTime = 0.5f;
            return 25;
        }
        else
        {
            stabilityTime = 0.2f;
            return 10;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Player") && !isStable)
        {
            gameObject.GetComponent<Renderer>().material = mat;
            Destroy(gameObject, stabilityTime);
        }
    }

}