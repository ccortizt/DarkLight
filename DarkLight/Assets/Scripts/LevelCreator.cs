
using System.Collections;
using UnityEngine;
public class LevelCreator: MonoBehaviour {
    
    public GameObject prefabPlatform;
    public GameObject prefabDoublePlatform;
    public GameObject prefabDestroyPlatform;
    public GameObject prefabDoubleDestroyPlatform;
    public GameObject prefabEnergy;
    public GameObject prefabEnemyBug;
    public GameObject prefabEnemyFire;
    public GameObject prefabDoor;
    public GameObject prefabCannon;
   

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
    int minFireRange;
    int maxFireRange;
    int minPlatformRange;
    int maxPlatformRange;
    int destroyWallPercentage;
    float destroyWallVelocityProportion;
    int numberOfEnemyBugs;
    float enemyBugInstanceTime;
    bool isBugAtackEnabled;
    float enemyBugVelocity;
    float enemyBugDrain;
    float cannonsProbability;
    float arrowfrequency;
    float arrowForce;

    void Start()
    {

        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");

        minEnergyRange = manager.GetComponent<LevelDifficultyController>().MinEnergyRange;
        maxEnergyRange = manager.GetComponent<LevelDifficultyController>().MaxEnergyRange;
        minFireRange = manager.GetComponent<LevelDifficultyController>().MinEnergyRange;
        maxFireRange = manager.GetComponent<LevelDifficultyController>().MaxEnergyRange;
        minPlatformRange = manager.GetComponent<LevelDifficultyController>().MinPlatformRange;
        maxPlatformRange = manager.GetComponent<LevelDifficultyController>().MaxPlatformRange;
        destroyWallPercentage = manager.GetComponent<LevelDifficultyController>().DestroyWallPercentage;
        waitDestroyTime = manager.GetComponent<LevelDifficultyController>().DestroyWallWaitTime;
        platformSizePercentageChooser = manager.GetComponent<LevelDifficultyController>().PlatformSizePercentage;
        numberOfEnemyBugs = manager.GetComponent<LevelDifficultyController>().EnemyBugProportion;
        enemyBugInstanceTime = manager.GetComponent<LevelDifficultyController>().EnemyBugInstanceTime;
        isBugAtackEnabled = manager.GetComponent<LevelDifficultyController>().EnableBugAtack;
        enemyBugVelocity = manager.GetComponent<LevelDifficultyController>().EnemyBugVelocity;
        enemyBugDrain = manager.GetComponent<LevelDifficultyController>().EnemyBugEnergyDrain;
        cannonsProbability = manager.GetComponent<LevelDifficultyController>().CannonPercentage;
        arrowfrequency = manager.GetComponent<LevelDifficultyController>().MinArrowFrequencyTime;
        arrowForce = manager.GetComponent<LevelDifficultyController>().ArrowForce;
        

        FillMap();
        AddEnergyPrefabs();       
        AddCannons();
        AddFirePrefabs();
        StartCoroutine(AddEnemyBugs());
        PutDoor();
        StartCoroutine(DestroyMap());
    }

    private IEnumerator AddEnemyBugs()
    {
        for (int i = 0; i < numberOfEnemyBugs; i++)
        {
            yield return new WaitForSeconds(enemyBugInstanceTime);
            var b = (GameObject)Instantiate(prefabEnemyBug, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position.y + 4, 8f), 0), Quaternion.identity);
            b.GetComponent<BugController>().SetVelocity(enemyBugVelocity);
            b.GetComponent<BugController>().SetEnergyDrain(enemyBugVelocity);
            b.transform.GetChild(0).gameObject.GetComponent<ProximityController>().SetCanHit(isBugAtackEnabled);
            b.name = b.name + " " + i;
           
        }
    }
    

    private void AddEnergyPrefabs()
    {
        int basePosY = 7;

        for (int i = basePosY; i < levelYSize; i += (int)Random.Range(minEnergyRange,maxEnergyRange) * 4)
        {
            Instantiate(prefabEnergy, new Vector3(Random.Range(0, levelXSize) - RandomPositionX(), i + RandomPositionY(), 0f), Quaternion.identity);
        }
    }

    private void AddFirePrefabs()
    {
        int basePosY = 7;

        for (int i = basePosY; i < levelYSize; i += (int)Random.Range(minFireRange, maxFireRange) * 2)
        {
            Instantiate(prefabEnemyFire, new Vector3(Random.Range(0, levelXSize) - RandomPositionX(), i + RandomPositionY(), 0f), Quaternion.identity);
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

    private void AddCannons()
    {
        for (int i = 1; i < levelYSize; i += 2)
        {
            GameObject rightCanon;
            GameObject leftCanon;
            if (Random.Range(0, 10) < cannonsProbability)
            {
                rightCanon = Instantiate(prefabCannon, new Vector3(-5.505f, i + RandomPositionY(), 0), Quaternion.identity);
                rightCanon.GetComponent<ArrowShooter>().SetArrowFrequency(arrowfrequency);
                rightCanon.GetComponent<ArrowShooter>().SetArrowForce(arrowForce);
            }

            if (Random.Range(0, 10) < cannonsProbability)
            {
                leftCanon = Instantiate(prefabCannon, new Vector3(5.505f, i + RandomPositionY(), 0), Quaternion.Euler(0, 180, 0));
                leftCanon.GetComponent<ArrowShooter>().SetArrowFrequency(arrowfrequency);
                leftCanon.GetComponent<ArrowShooter>().SetArrowForce(arrowForce);
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