
using System.Collections;
using UnityEngine;
public class LevelCreator : MonoBehaviour
{

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

    private float yAxisDoorPosition = 55.3f;

    private float minBaseValueY = 0.58f; //0.4f
    private float maxBaseValueY = 1.15f; //0.7f

    private float platformSizePercentageChooser = 4;

    private float waitDestroyTime = 3;


    int minEnergyRange;
    int maxEnergyRange;
    int minFireRange;
    int maxFireRange;
    float fireVelocity;
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
        fireVelocity = manager.GetComponent<LevelDifficultyController>().FireVelocity;
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
            var b = (GameObject)Instantiate(prefabEnemyBug, new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position.y + 3.5f, 5.5f), 0), Quaternion.identity);

            b.GetComponent<BugController>().SetVelocity(enemyBugVelocity);
            b.GetComponent<BugController>().SetEnergyDrain(enemyBugDrain);
            b.transform.GetChild(0).gameObject.GetComponent<BugProximityController>().SetCanHit(isBugAtackEnabled);
            b.name = b.name + " " + i;

        }
    }

    private void AddEnergyPrefabs()
    {
        int basePosY = 7;

        for (int i = basePosY; i < levelYSize; i += (int)Random.Range(minEnergyRange, maxEnergyRange) * 4)
        {
            Instantiate(prefabEnergy, new Vector3(Random.Range(0, levelXSize) - RandomPositionX(), i + RandomPositionY(), 0f), Quaternion.identity);
        }
    }

    private void AddFirePrefabs()
    {
        int basePosY = 7;

        for (int i = basePosY; i < levelYSize; i += (int)Random.Range(minFireRange, maxFireRange) * 2)
        {
            var f = (GameObject)Instantiate(prefabEnemyFire, new Vector3(Random.Range(0, levelXSize) - RandomPositionX(), i + RandomPositionY(), 0f), Quaternion.identity);
            f.gameObject.GetComponent<FireMovement>().SetVelocity(fireVelocity);
            
        }
    }

    public IEnumerator DestroyMap()
    {
        if (destroyWallPercentage != 0)
        {
            for (int i = 0; i < levelYSize; i += (2 * destroyWallPercentage))
            {
                yield return new WaitForSeconds(waitDestroyTime * destroyWallPercentage);
                var p = (GameObject)Instantiate(prefabDestroyPlatform, new Vector3(RandomDestroyPlatformSide() * 10, i, 0), Quaternion.identity);
                p.GetComponent<PlatformDestroyController>().SetProportion(destroyWallPercentage);

            }
        }

    }

    private void FillMap()
    {
        int numberPlatformsY;
        
        for (int i = 0; i < levelYSize; i += 2)
        {
            numberPlatformsY = RandomNumberPlatformAxisY(); //2,6

            for (int j = 0; j < levelXSize; j++)
            {
                if (Random.Range(0, 10) < numberPlatformsY)
                {
                    if (RandomPlatformSize())
                    {
                        var p = (GameObject)Instantiate(prefabPlatform, new Vector3(j - RandomPositionX(), i + RandomPositionY(), 0), Quaternion.identity);
                        p.transform.localScale = new Vector3(1, 0.5f, Random.Range(0.75f, 0.88f));
                    }

                    else
                    {
                        var p = (GameObject)Instantiate(prefabDoublePlatform, new Vector3(j - RandomPositionX(), i + RandomPositionY(), 0), Quaternion.identity);
                        p.transform.localScale = new Vector3(1, 0.5f, Random.Range(0.85f, 0.95f));
                    }
                }

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
        return Random.Range(minBaseValueY, maxBaseValueY);
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
        }
        else
            return 1;
    }

}