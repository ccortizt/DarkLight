using System.Collections;
using UnityEngine;
public class PlatformController: MonoBehaviour{

    private bool isStable;
    private float stabilityTime = 2.5f;
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