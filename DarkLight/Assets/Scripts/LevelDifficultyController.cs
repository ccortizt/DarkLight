using System;
using System.Collections.Generic;
using UnityEngine;
public class LevelDifficultyController : MonoBehaviour
{

    int minEnergyRange;

    public int MinEnergyRange
    {
        get { return minEnergyRange; }
        set { minEnergyRange = value; }
    }

    int maxEnergyRange;

    public int MaxEnergyRange
    {
        get { return maxEnergyRange; }
        set { maxEnergyRange = value; }
    }

    int minFireRange;

    public int MinFireRange
    {
        get { return minFireRange; }
        set { minFireRange = value; }
    }

    int maxFireRange;

    public int MaxFireRange
    {
        get { return maxFireRange; }
        set { maxFireRange = value; }
    }

    float fireVelocity;

    public float FireVelocity
    {
        get { return fireVelocity; }
        set { fireVelocity = value; }
    }

    int minPlatformRange;

    public int MinPlatformRange
    {
        get { return minPlatformRange; }
        set { minPlatformRange = value; }
    }
    int maxPlatformRange;

    public int MaxPlatformRange
    {
        get { return maxPlatformRange; }
        set { maxPlatformRange = value; }
    }

    int destroyWallPercentage;

    public int DestroyWallPercentage
    {
        get { return destroyWallPercentage; }
        set { destroyWallPercentage = value; }
    }

    float destroyWallWaitTime;

    public float DestroyWallWaitTime
    {
        get { return destroyWallWaitTime; }
        set { destroyWallWaitTime = value; }
    }

    float destroyWallVelocityProportion;

    public float DestroyWallVelocityProportion
    {
        get { return destroyWallVelocityProportion; }
        set { destroyWallVelocityProportion = value; }
    }


    float cannonPercentage;

    public float CannonPercentage
    {
        get { return cannonPercentage; }
        set { cannonPercentage = value; }

    }


    float minArrowFrequencyTime;

    public float MinArrowFrequencyTime
    {
        get { return minArrowFrequencyTime; }
        set { minArrowFrequencyTime = value; }
    }

    float arrowForce;

    public float ArrowForce
    {
        get { return arrowForce; }
        set { arrowForce = value; }
    }


    float platformSizePercentage;

    public float PlatformSizePercentage
    {
        get { return platformSizePercentage; }
        set { platformSizePercentage = value; }
    }

    int enemyBugQuantity;

    public int EnemyBugProportion
    {
        get { return enemyBugQuantity; }
        set { enemyBugQuantity = value; }
    }

    float enemyBugInstanceTime;

    public float EnemyBugInstanceTime
    {
        get { return enemyBugInstanceTime; }
        set { enemyBugInstanceTime = value; }
    }


    bool enableBugAtack;

    public bool EnableBugAtack
    {
        get { return enableBugAtack; }
        set { enableBugAtack = value; }
    }

    float enemyBugVelocity;

    public float EnemyBugVelocity
    {
        get { return enemyBugVelocity; }
        set { enemyBugVelocity = value; }
    }

    float enemyBugEnergyDrain;
    public float EnemyBugEnergyDrain
    {
        get { return enemyBugEnergyDrain; }
        set { enemyBugEnergyDrain = value; }
    }




    void Start()
    {
        SetDifficultyProportions(GetComponent<LevelProgressController>().GetLevel());
    }

    public void SetDifficultyNotStart()
    {
        SetDifficultyProportions(GetComponent<LevelProgressController>().GetLevel());
    }

    public void SetDifficultyProportions(int difficulty)
    {
        switch (difficulty)
        {
            case 1:

                minEnergyRange = 3;
                maxEnergyRange = 7;
                minFireRange = 4;
                maxFireRange = 6;
                fireVelocity = 0f;
                minPlatformRange = 1;
                maxPlatformRange = 7;
                destroyWallPercentage = 0;
                destroyWallWaitTime = 3f;
                destroyWallVelocityProportion = 0f;
                platformSizePercentage = 4.5f;
                enemyBugQuantity = 5;
                enemyBugInstanceTime = 5.5f;
                enableBugAtack = false;
                enemyBugVelocity = 0.9f;
                enemyBugEnergyDrain = 0f;
                cannonPercentage = 2.2f;
                minArrowFrequencyTime = 7f;
                arrowForce = 5.5f;

                break;
            case 2:
                minEnergyRange = 3;
                maxEnergyRange = 7;
                minFireRange = 4;
                maxFireRange = 6;
                fireVelocity = 0.02f;
                minPlatformRange = 1;
                maxPlatformRange = 7;
                destroyWallPercentage = 0;
                destroyWallWaitTime = 3f;
                destroyWallVelocityProportion = 0f;
                platformSizePercentage = 4f;
                enemyBugQuantity = 7;
                enemyBugInstanceTime = 5f;
                enableBugAtack = false;
                enemyBugVelocity = 1f;
                enemyBugEnergyDrain = 0.35f;
                cannonPercentage = 2.2f;
                minArrowFrequencyTime = 6.3f;
                arrowForce = 6f;


                break;

            case 3:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                minFireRange = 5;
                maxFireRange = 8;
                fireVelocity = 0.02f;
                minPlatformRange = 2;
                maxPlatformRange = 5;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 2.5f;
                destroyWallVelocityProportion = 1f;
                platformSizePercentage = 2.5f;
                enemyBugQuantity = 6;
                enemyBugInstanceTime = 5f;
                enableBugAtack = true;
                enemyBugVelocity = 1f;
                enemyBugEnergyDrain = 0.5f;
                cannonPercentage = 2.8f;
                minArrowFrequencyTime = 5.5f;
                arrowForce = 6f;


                break;
            case 4:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                minFireRange = 5;
                maxFireRange = 8;
                fireVelocity = 0.04f;
                minPlatformRange = 2;
                maxPlatformRange = 5;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 2.5f;
                destroyWallVelocityProportion = 1f;
                platformSizePercentage = 3f;
                enemyBugQuantity = 8;
                enemyBugInstanceTime = 5f;
                enableBugAtack = true;
                enemyBugVelocity = 1.1f;
                enemyBugEnergyDrain = 0.5f;
                cannonPercentage = 2.8f;
                minArrowFrequencyTime = 5.2f;
                arrowForce = 7f;

                break;
            case 5:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                minFireRange = 5;
                maxFireRange = 8;
                fireVelocity = 0.04f;
                minPlatformRange = 2;
                maxPlatformRange = 5;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 2.1f;
                destroyWallVelocityProportion = 1.1f;
                platformSizePercentage = 3f;
                enemyBugQuantity = 9;
                enemyBugInstanceTime = 5f;
                enableBugAtack = true;
                enemyBugVelocity = 1.1f;
                enemyBugEnergyDrain = 0.9f;
                cannonPercentage = 3.6f;
                minArrowFrequencyTime = 5.2f;
                arrowForce = 7f;

                break;

            case 6:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                minFireRange = 5;
                maxFireRange = 8;
                fireVelocity = 0.04f;
                minPlatformRange = 2;
                maxPlatformRange = 5;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 2.1f;
                destroyWallVelocityProportion = 1.25f;
                platformSizePercentage = 3f;
                enemyBugQuantity = 9;
                enemyBugInstanceTime = 4.5f;
                enableBugAtack = true;
                enemyBugVelocity = 1.1f;
                enemyBugEnergyDrain = 1.2f;
                cannonPercentage = 3.6f;
                minArrowFrequencyTime = 4.8f;
                arrowForce = 8.5f;

                break;
            case 7:
                minEnergyRange = 3;
                maxEnergyRange = 5;
                minFireRange = 6;
                maxFireRange = 10;
                fireVelocity = 0.04f;
                minPlatformRange = 2;
                maxPlatformRange = 5;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 1.8f;
                destroyWallVelocityProportion = 1.25f;
                platformSizePercentage = 3f;
                enemyBugQuantity = 9;
                enemyBugInstanceTime = 4.5f;
                enableBugAtack = true;
                enemyBugVelocity = 1.2f;
                enemyBugEnergyDrain = 0.9f;
                cannonPercentage = 4.8f;
                minArrowFrequencyTime = 3.5f;
                arrowForce = 8.5f;

                break;
            case 8:
                minEnergyRange = 3;
                maxEnergyRange = 5;
                minFireRange = 6;
                maxFireRange = 10;
                fireVelocity = 0.04f;
                minPlatformRange = 2;
                maxPlatformRange = 6;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 1.8f;
                destroyWallVelocityProportion = 1.35f;
                platformSizePercentage = 2.5f;
                enemyBugQuantity = 10;
                enemyBugInstanceTime = 4.5f;
                enableBugAtack = true;
                enemyBugVelocity = 1.2f;
                enemyBugEnergyDrain = 1.5f;
                cannonPercentage = 4.8f;
                minArrowFrequencyTime = 3.5f;
                arrowForce = 8.5f;


                break;

            case 9:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                minFireRange = 7;
                maxFireRange = 10;
                fireVelocity = 0.05f;
                minPlatformRange = 3;
                maxPlatformRange = 6;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 1.4f;
                destroyWallVelocityProportion = 1.6f;
                platformSizePercentage = 2.5f;
                enemyBugQuantity = 10;
                enemyBugInstanceTime = 4f;
                enableBugAtack = true;
                enemyBugVelocity = 1.2f;
                enemyBugEnergyDrain = 1.5f;
                cannonPercentage = 5.7f;
                minArrowFrequencyTime = 3.5f;
                arrowForce = 8.5f;


                break;
            case 10:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                minFireRange = 7;
                maxFireRange = 10;
                fireVelocity = 0.05f;
                minPlatformRange = 3;
                maxPlatformRange = 6;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 1.25f;
                destroyWallVelocityProportion = 1.7f;
                platformSizePercentage = 2f;
                enemyBugQuantity = 12;
                enemyBugInstanceTime = 4f;
                enableBugAtack = true;
                enemyBugVelocity = 1.2f;
                enemyBugEnergyDrain = 2f;
                cannonPercentage = 5.7f;
                minArrowFrequencyTime = 2f;
                arrowForce = 8.5f;


                break;
            case 11:
                minEnergyRange = 3;
                maxEnergyRange = 5;
                minFireRange = 5;
                maxFireRange = 8;
                fireVelocity = 0.065f;
                minPlatformRange = 2;
                maxPlatformRange = 5;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 0.9f;
                destroyWallVelocityProportion = 1.95f;
                platformSizePercentage = 2f;
                enemyBugQuantity = 10;
                enemyBugInstanceTime = 3.75f;
                enableBugAtack = true;
                enemyBugVelocity = 1.3f;
                enemyBugEnergyDrain = 2f;
                cannonPercentage = 7.7f;
                minArrowFrequencyTime = 2f;
                arrowForce = 10f;


                break;
            case 12:
                minEnergyRange = 4;
                maxEnergyRange = 7;
                minFireRange = 6;
                maxFireRange = 10;
                fireVelocity = 0.065f;
                minPlatformRange = 1;
                maxPlatformRange = 7;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 0.85f;
                destroyWallVelocityProportion = 1.95f;
                platformSizePercentage = 2f;
                enemyBugQuantity = 12;
                enemyBugInstanceTime = 4f;
                enableBugAtack = true;
                enemyBugVelocity = 1.3f;
                enemyBugEnergyDrain = 2f;
                cannonPercentage = 7.7f;
                minArrowFrequencyTime = 1.8f;
                arrowForce = 10f;


                break;
            default:
                minEnergyRange = 2;
                maxEnergyRange = 7;
                minFireRange = 7;
                maxFireRange = 10;
                fireVelocity = 0.1f;
                minPlatformRange = 3;
                maxPlatformRange = 6;
                destroyWallPercentage = 1;
                destroyWallWaitTime = 3f;
                destroyWallVelocityProportion = 0f;
                platformSizePercentage = 5f;
                enemyBugQuantity = 6;
                enemyBugInstanceTime = 5.5f;
                enableBugAtack = false;
                enemyBugVelocity = 1f;
                enemyBugEnergyDrain = 0f;
                cannonPercentage = 2.2f;
                minArrowFrequencyTime = 7f;
                arrowForce = 5.5f;

                break;
        }

    }


}
