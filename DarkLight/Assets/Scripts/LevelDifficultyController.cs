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

    float enemyBugVelocity;
    public float EnemyBugVelocity
    {
        get { return enemyBugVelocity; }
        set { enemyBugVelocity = value; }
    }


    void Start()
    {
        SetDifficultyProportions(GetComponent<LevelProgressController>().GetLevel());
    }

    public void SetDifficultyProportions(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                SetEnergyRange(0);
                SetPlatformRange(0);
                SetDestroyWallProportion(0);
                SetDestroyWallWaitTime(1);
                SetDestroyWallVelocityProp(0);
                SetPlatformSizePercentage(1);
                SetNumberOfBugEnemy(1);
                SetVelocityOfEnemyBug(-1);

                break;
            case 2:
                SetEnergyRange(1);
                SetPlatformRange(0);
                SetDestroyWallProportion(1);
                SetDestroyWallWaitTime(1);
                SetDestroyWallVelocityProp(1);
                SetPlatformSizePercentage(-1);
                SetNumberOfBugEnemy(2);
                SetVelocityOfEnemyBug(-1);
                break;
            case 3:
                SetEnergyRange(1);
                SetPlatformRange(1);
                SetDestroyWallProportion(2);
                SetDestroyWallWaitTime(-1);
                SetDestroyWallVelocityProp(1);
                SetPlatformSizePercentage(2);
                SetNumberOfBugEnemy(2);
                SetVelocityOfEnemyBug(-1);
                break;
            case 4:
                SetEnergyRange(1);
                SetPlatformRange(1);
                SetDestroyWallProportion(3);
                SetDestroyWallWaitTime(-1);
                SetDestroyWallVelocityProp(1);
                SetPlatformSizePercentage(2);
                SetNumberOfBugEnemy(2);
                SetVelocityOfEnemyBug(-1);
                break;
            case 5:
                SetEnergyRange(0);
                SetPlatformRange(0);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(2);
                SetDestroyWallVelocityProp(2);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(2);
                SetVelocityOfEnemyBug(1);
                break;
            case 6:
                SetEnergyRange(1);
                SetPlatformRange(0);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(2);
                SetDestroyWallVelocityProp(2);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(2);
                SetVelocityOfEnemyBug(2);

                break;
            case 7:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(3);
                SetDestroyWallVelocityProp(2);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(3);
                SetVelocityOfEnemyBug(2);
                
                break;
            case 8:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(3);
                SetDestroyWallVelocityProp(3);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(3);
                SetVelocityOfEnemyBug(2);
                
                break;
            case 9:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(3);
                SetDestroyWallVelocityProp(3);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(3);
                SetVelocityOfEnemyBug(3);
                break;
            case 10:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(4);
                SetDestroyWallVelocityProp(4);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(3);
                SetVelocityOfEnemyBug(3);
                
                break;
            case 11:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(4);
                SetDestroyWallVelocityProp(4);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetVelocityOfEnemyBug(3);
                
                break;
            case 12:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(4);
                SetDestroyWallVelocityProp(5);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetVelocityOfEnemyBug(3);
                
                break;
            case 13:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(4);
                SetDestroyWallVelocityProp(5);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetVelocityOfEnemyBug(3);
                
                break;
            case 14:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(5);
                SetDestroyWallVelocityProp(6);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetVelocityOfEnemyBug(4);
                
                break;
            case 15:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(5);
                SetDestroyWallVelocityProp(7);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetVelocityOfEnemyBug(4);
                
                break;
            default:
                SetEnergyRange(0);
                SetPlatformRange(0);
                SetDestroyWallProportion(-1);
                SetDestroyWallWaitTime(-1);
                SetDestroyWallVelocityProp(2);
                SetPlatformSizePercentage(-1);
                SetNumberOfBugEnemy(1);
                SetVelocityOfEnemyBug(-1);
                break;
        }

    }

    private void SetEnergyRange(int proportion)
    {
        //1,N,2

        switch (proportion)
        {
            case 1:
                minEnergyRange = 3;
                maxEnergyRange = 6;
                break;
            case 2:

                minEnergyRange = 3;
                maxEnergyRange = 5;
                break;
            default:
                minEnergyRange = 2;
                maxEnergyRange = 5;
                break;
        }
    }

    private void SetPlatformRange(int proportion)
    {
        //1,N,2 +probability

        switch (proportion)
        {
            case 1:
                minPlatformRange = 2;
                maxPlatformRange = 5;
                break;
            case 2:
                minPlatformRange = 3;
                maxPlatformRange = 7;
                break;
            default:
                minPlatformRange = 2;
                maxPlatformRange = 6;
                break;
        }
    }

    private void SetDestroyWallProportion(int proportion)
    {

        switch (proportion)
        {
            case 0:
                destroyWallPercentage = 0;
                break;
            case 1:
                destroyWallPercentage = 5;
                break;
            case 2:
                destroyWallPercentage = 3;
                break;
            case 3:
                destroyWallPercentage = 2;
                break;
            case 4:
                destroyWallPercentage = 1;
                break;
            default:
                destroyWallPercentage = 1;
                break;
        }
    }

    private void SetDestroyWallVelocityProp(int proportion)
    {

        switch (proportion)
        {

            case 1:
                destroyWallVelocityProportion = 0.25f;
                break;
            case 2:
                destroyWallVelocityProportion = 0.5f;
                break;
            case 3:
                destroyWallVelocityProportion = 0.6f;
                break;
            case 4:
                destroyWallVelocityProportion = 0.7f;
                break;
            case 5:
                destroyWallVelocityProportion = 1f;
                break;
            case 6:
                destroyWallVelocityProportion = 1.5f;
                break;
            case 7:
                destroyWallVelocityProportion = 1.8f;
                break;
            default:
                destroyWallVelocityProportion = 0;
                break;
        }
    }

    private void SetDestroyWallWaitTime(int proportion)
    {

        switch (proportion)
        {

            case 1:
                destroyWallWaitTime = 3.5f;
                break;
            case 2:
                destroyWallWaitTime = 2.8f;
                break;
            case 3:
                destroyWallWaitTime = 2.4f;
                break;
            case 4:
                destroyWallWaitTime = 2f;
                break;
            case 5:
                destroyWallWaitTime = 2.5f;
                break;

            default:
                destroyWallWaitTime = 3;
                break;
        }
    }


    private void SetPlatformSizePercentage(int proportion)
    {

        switch (proportion)
        {

            case 1:
                platformSizePercentage = 4.5f;
                break;
            case 2:
                platformSizePercentage = 3f;
                break;
            case 3:
                platformSizePercentage = 3.5f;
                break;
            case 4:
                platformSizePercentage = 2f;
                break;
            default:
                platformSizePercentage = 4;
                break;
        }
    }
    private void SetNumberOfBugEnemy(int quantity)
    {
        switch (quantity)
        {

            case 1:
                enemyBugQuantity = 3;
                break;
            case 2:
                enemyBugQuantity = 5;
                break;
            case 3:
                enemyBugQuantity = 8;
                break;
            case 4:
                enemyBugQuantity = 10;
                break;
            default:
                enemyBugQuantity = 4;
                break;
        }
    }

    private void SetVelocityOfEnemyBug(int percentage)
    {

        switch (percentage)
        {

            case 1:
                enemyBugVelocity = 1.5f;
                break;
            case 2:
                enemyBugVelocity = 2;
                break;
            case 3:
                enemyBugVelocity = 3.5f;
                break;
            case 4:
                enemyBugVelocity = 5;
                break;
            default:
                enemyBugVelocity = 1;
                break;
        }
    }

}
