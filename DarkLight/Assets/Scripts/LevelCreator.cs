
using System.Collections;
using UnityEngine;
public class LevelCreator: MonoBehaviour{
    
    public GameObject prefabPlatform;
    public GameObject prefabDoublePlatform;
    public GameObject prefabDestroyPlatform;

    private float minBaseValueX = 4.35f;
    private float maxBaseValueX = 4.55f;

    private int minPlatformsPerY = 2;
    private int maxPlatformsPerY = 6;

    //private float baseValueX = 4.5f;

    private float minBaseValueY = 0.4f;
    private float maxBaseValueY = 0.7f;

    private float platformSizePercentageChooser = 4;

    private float waitDestroyTime = 3;

    private bool[,] platformMap = new bool[50, 10];


    void Start()
    {
        InitializePlatformMap();
        FillMap();
        StartCoroutine(DestroyMap());
    }

    private void InitializePlatformMap()
    {
        for (int i = 0; i < 50; i++)
            for (int j = 0; j < 10; j++)
                platformMap[i, j] = false;
    }

    private void FillMap()
    {
        int numberPlatformsY;

        for (int i = 0; i < 50; i+=2)
        {
            numberPlatformsY = RandomNumberPlatformAxisY();
            
            for (int j = 0; j < 10; j++)
            {
                if(Random.Range(0,10) < numberPlatformsY)
                    if(RandomPlatformSize())
                        Instantiate(prefabPlatform, new Vector3(j - RandomPositionX(), i + RandomPositionY(), 0), Quaternion.identity);
                    else
                        Instantiate(prefabDoublePlatform, new Vector3(j - RandomPositionX(), i + RandomPositionY(), 0), Quaternion.identity);
            }
            
        }
    }

    public IEnumerator DestroyMap()
    {
        for (int i = 1; i < 50; i+=2)
        {
            yield return new WaitForSeconds(waitDestroyTime);
            Instantiate(prefabDestroyPlatform, new Vector3(RandomDestroyPlatformSide() * 10, i - 1f, 0), Quaternion.identity);
        }
    }

    private float RandomPositionY()
    {
        return Random.Range(minBaseValueY,maxBaseValueY);
    }

    private float RandomPositionX()
    {
        return Random.Range(minBaseValueX, maxBaseValueX);
    }

    private int RandomNumberPlatformAxisY()
    {
        return Random.Range(minPlatformsPerY, maxPlatformsPerY);
    }

    private bool RandomPlatformSize()
    {
        return Random.Range(0, 10) > platformSizePercentageChooser;
    }

    private int RandomDestroyPlatformSide()
    {
        if (Random.Range(0, 10) >= 5)
        {
            return -1;
        } else 
            return 1;
    }

}