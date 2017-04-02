
using System.Collections;
using UnityEngine;
public class LevelCreator: MonoBehaviour {
    
    public GameObject prefabPlatform;
    public GameObject prefabDoublePlatform;
    public GameObject prefabDestroyPlatform;
    public GameObject prefabDoubleDestroyPlatform;
    public GameObject prefabEnergy;
    public GameObject prefabEnemy;
    public GameObject prefabDoor;

   

    private int levelYSize = 52;
    private int levelXSize = 10;

    private float minBaseValueX = 4.35f;
    private float maxBaseValueX = 4.55f;

    //private int minPlatformsPerY = 2;
    //private int maxPlatformsPerY = 6;

    private float yAxisDoorPosition = 55.3f;

    private float minBaseValueY = 0.4f;
    private float maxBaseValueY = 0.7f;

    private float platformSizePercentageChooser = 4;

    private float waitDestroyTime = 3;

    int minEnergyRange;
    int maxEnergyRange;
    int minPlatformRange;
    int maxPlatformRange;
    int destroyWallPercentage;
    float destroyWallVelocityProportion;

    void Start()
    {        
        minEnergyRange = GameObject.Find("LevelProgressManager").GetComponent<LevelDifficultyController>().MinEnergyRange;
        maxEnergyRange = GameObject.Find("LevelProgressManager").GetComponent<LevelDifficultyController>().MaxEnergyRange;
        minPlatformRange = GameObject.Find("LevelProgressManager").GetComponent<LevelDifficultyController>().MinPlatformRange;
        maxPlatformRange = GameObject.Find("LevelProgressManager").GetComponent<LevelDifficultyController>().MaxPlatformRange;
        destroyWallPercentage = GameObject.Find("LevelProgressManager").GetComponent<LevelDifficultyController>().DestroyWallPercentage;
            
        FillMap();
        AddEnergyPrefabs();
        PutDoor();
        StartCoroutine(DestroyMap());
    }
    

    private void AddEnergyPrefabs()
    {
        int basePosY = 7;

        for (int i = basePosY; i < levelYSize; i += (int)Random.Range(minEnergyRange,maxEnergyRange) * 2)
        {
            Instantiate(prefabEnergy, new Vector3(Random.Range(0, levelXSize) - RandomPositionX(), i + RandomPositionY(), 0f), Quaternion.identity);
        }
    }

    public IEnumerator DestroyMap()
    {
        if (destroyWallPercentage != 0)
        {
            for (int i = 0; i < levelYSize; i += (2 * destroyWallPercentage))
            {
                yield return new WaitForSeconds(waitDestroyTime * destroyWallPercentage);
                var p = (GameObject)Instantiate(prefabDestroyPlatform, new Vector3(RandomDestroyPlatformSide() * 10, i , 0), Quaternion.identity);
                p.GetComponent<PlatformDestroyController>().SetProportion(destroyWallPercentage);
            }
        }
        
    }

    private void FillMap()
    {
        int numberPlatformsY;

        for (int i = 0; i < levelYSize; i+=2)
        {
            numberPlatformsY = RandomNumberPlatformAxisY();
            
            for (int j = 0; j < levelXSize; j++)
            {
                if(Random.Range(0,10) < numberPlatformsY)
                    if(RandomPlatformSize())
                        Instantiate(prefabPlatform, new Vector3(j - RandomPositionX(), i + RandomPositionY(), 0), Quaternion.identity);
                    else
                        Instantiate(prefabDoublePlatform, new Vector3(j - RandomPositionX(), i + RandomPositionY(), 0), Quaternion.identity);
            }
            
        }
    }

    private void PutDoor()
    {
        Instantiate(prefabDoor, new Vector3(Random.Range(0, levelXSize) - RandomPositionX(), yAxisDoorPosition, 0f), Quaternion.identity);
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
        return Random.Range(minPlatformRange, maxPlatformRange);
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