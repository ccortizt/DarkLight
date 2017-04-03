using System.Collections;
using UnityEngine;
public class PlatformController: MonoBehaviour{

    private bool isStable;
    private float stabilityTime = 3.0f;
    public Material mat;

    void Start()
    {
        SetStability(SetProbability(GameObject.Find("LevelProgressManager").GetComponent<LevelProgressController>().GetLevel()));
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
            stabilityTime = 3f;
            return 97;
        }

        if (lvl >= 3 && lvl < 5)
        {
            stabilityTime = 2.8f;
            return 92;
        }

        if (lvl >= 5 && lvl < 7)
        {
            stabilityTime = 2.6f;
            return 85;
        }

        if (lvl >= 7 && lvl < 10)
        {
            stabilityTime = 2f;
            return 75;
        }
        else
        {
            stabilityTime = 1.5f;
            return 62;
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