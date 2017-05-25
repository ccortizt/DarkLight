﻿using System;
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
                SetEnergyRange(-1);
                SetFireRange(1);
                SetFireVelocity(0);
                SetPlatformRange(2);
                SetDestroyWallProportion(0);
                SetDestroyWallWaitTime(1);
                SetDestroyWallVelocityProp(0);
                SetPlatformSizePercentage(1);
                SetNumberOfBugEnemy(1);
                SetVelocityOfEnemyBug(-1);
                SetTimeSpawnBug(-1);
                SetEnableBugEnemy(0);
                SetDrainEnergyOfEnemyBug(-1);
                SetCannonProportion(-1);
                SetMinArrowFrequency(-1);
                SetArrowForce(1);

                break;
            case 2:
                SetEnergyRange(-1);
                SetFireRange(1);
                SetFireVelocity(1);
                SetPlatformRange(2);
                SetDestroyWallProportion(0);
                SetDestroyWallWaitTime(1);
                SetDestroyWallVelocityProp(1);
                SetPlatformSizePercentage(-1);
                SetNumberOfBugEnemy(0);
                SetTimeSpawnBug(1);
                SetVelocityOfEnemyBug(-1);
                SetEnableBugEnemy(0);
                SetDrainEnergyOfEnemyBug(-1);
                SetCannonProportion(-1);
                SetMinArrowFrequency(-1);
                SetArrowForce(2);

                break;
          
            case 3:
                SetEnergyRange(1);
                SetFireRange(2);
                SetFireVelocity(2);
                SetPlatformRange(1);
                SetDestroyWallProportion(1);
                SetDestroyWallWaitTime(1);
                SetDestroyWallVelocityProp(1);
                SetPlatformSizePercentage(2);
                SetNumberOfBugEnemy(1);
                SetTimeSpawnBug(2);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(-1);
                SetDrainEnergyOfEnemyBug(-1);
                SetCannonProportion(1);
                SetMinArrowFrequency(-1);
                SetArrowForce(2);

                break;
            case 4:
                SetEnergyRange(1);
                SetFireRange(2);
                SetFireVelocity(2);
                SetPlatformRange(1);
                SetDestroyWallProportion(1);
                SetDestroyWallWaitTime(-1);
                SetDestroyWallVelocityProp(2);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(2);
                SetTimeSpawnBug(2);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(1);
                SetDrainEnergyOfEnemyBug(1);
                SetCannonProportion(1);
                SetMinArrowFrequency(1);
                SetArrowForce(3);
                break;
            case 5:
                SetEnergyRange(1);
                SetFireRange(2);
                SetFireVelocity(3);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(2);
                SetDestroyWallVelocityProp(2);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(2);
                SetTimeSpawnBug(2);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(2);
                SetDrainEnergyOfEnemyBug(1);
                SetCannonProportion(2);
                SetMinArrowFrequency(1);
                SetArrowForce(3);
                break;
            
            case 6:
                SetEnergyRange(1);
                SetFireRange(3);
                SetFireVelocity(3);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(2);
                SetDestroyWallVelocityProp(3);
                SetPlatformSizePercentage(3);
                SetNumberOfBugEnemy(3);
                SetTimeSpawnBug(3);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(2);
                SetDrainEnergyOfEnemyBug(2);
                SetCannonProportion(2);
                SetMinArrowFrequency(2);
                SetArrowForce(4);
                break;
            case 7:
                SetEnergyRange(2);
                SetFireRange(3);
                SetFireVelocity(3);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(3);
                SetDestroyWallVelocityProp(3);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(3);
                SetTimeSpawnBug(3);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(3);
                SetDrainEnergyOfEnemyBug(3);
                SetCannonProportion(3);
                SetMinArrowFrequency(3);
                SetArrowForce(4);
                break;
            case 8:
                SetEnergyRange(2);
                SetFireRange(4);
                SetFireVelocity(4);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(3);
                SetDestroyWallVelocityProp(4);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(3);
                SetTimeSpawnBug(3);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(3);
                SetDrainEnergyOfEnemyBug(3);
                SetCannonProportion(3);
                SetMinArrowFrequency(3);
                SetArrowForce(4);

                break;
           
            case 9:
                SetEnergyRange(1);
                SetFireRange(4);
                SetFireVelocity(4);
                SetPlatformRange(0);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(4);
                SetDestroyWallVelocityProp(5);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetTimeSpawnBug(4);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(3);
                SetDrainEnergyOfEnemyBug(3);
                SetCannonProportion(4);
                SetMinArrowFrequency(3);
                SetArrowForce(5);

                break;
            case 10:
                SetEnergyRange(1);
                SetFireRange(3);
                SetFireVelocity(4);
                SetPlatformRange(0);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(4);
                SetDestroyWallVelocityProp(5);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetTimeSpawnBug(0);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(3);
                SetDrainEnergyOfEnemyBug(4);
                SetCannonProportion(4);
                SetMinArrowFrequency(4);
                SetArrowForce(5);

                break;
            case 11:
                SetEnergyRange(2);
                SetFireRange(2);
                SetFireVelocity(4);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(5);
                SetDestroyWallVelocityProp(6);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(3);
                SetTimeSpawnBug(4);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(4);
                SetDrainEnergyOfEnemyBug(4);
                SetCannonProportion(5);
                SetMinArrowFrequency(4);
                SetArrowForce(5);

                break;
            case 12:
                SetEnergyRange(1);
                SetFireRange(3);
                SetFireVelocity(4);
                SetPlatformRange(2);
                SetDestroyWallProportion(4);
                SetDestroyWallWaitTime(5);
                SetDestroyWallVelocityProp(7);
                SetPlatformSizePercentage(4);
                SetNumberOfBugEnemy(4);
                SetTimeSpawnBug(4);
                SetEnableBugEnemy(1);
                SetVelocityOfEnemyBug(4);
                SetDrainEnergyOfEnemyBug(4);
                SetCannonProportion(5);
                SetMinArrowFrequency(4);
                SetArrowForce(5);

                break;
            default:
                SetEnergyRange(0);
                SetFireRange(0);
                SetFireVelocity(2);
                SetPlatformRange(0);
                SetDestroyWallProportion(-1);
                SetDestroyWallWaitTime(-1);
                SetDestroyWallVelocityProp(0);
                SetPlatformSizePercentage(-1);
                SetNumberOfBugEnemy(1);
                SetVelocityOfEnemyBug(-1);
                SetTimeSpawnBug(0);
                SetEnableBugEnemy(-1);
                SetDrainEnergyOfEnemyBug(-1);
                SetCannonProportion(-1);
                SetMinArrowFrequency(-1);
                SetArrowForce(-1);
                break;
        }

    }

    private void SetEnergyRange(int proportion)
    {
        //1,N,2

        switch (proportion)
        {
            case 1:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                break;
            case 2:

                minEnergyRange = 3;
                maxEnergyRange = 5;
                break;
            default:
                minEnergyRange = 2;
                maxEnergyRange = 7;
                break;
        }
    }

    private void SetFireRange(int proportion)
    {

        switch (proportion)
        {
            case 1:
                minEnergyRange = 4;
                maxEnergyRange = 6;
                break;
            case 2:

                minEnergyRange = 5;
                maxEnergyRange = 8;
                break;
            case 3:

                minEnergyRange = 6;
                maxEnergyRange = 10;
                break;

            default:
                minEnergyRange = 7;
                maxEnergyRange = 10;
                break;
        }
    }

    private void SetFireVelocity(int proportion)
    {

        switch (proportion)
        {
            case 0:
                fireVelocity = 0f;
                break;
            case 1:
                fireVelocity = 0.02f;
                break;
            case 2:

                fireVelocity = 0.04f;
                break;
            case 3:

                fireVelocity = 0.065f;
                break;

            default:
                fireVelocity = 0.1f;
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
                minPlatformRange = 1;
                maxPlatformRange = 7;
                break;
            default:
                minPlatformRange = 3;
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
                destroyWallVelocityProportion = 0.75f;
                break;
            case 2:
                destroyWallVelocityProportion = 0.9f;
                break;
            case 3:
                destroyWallVelocityProportion = 1f;
                break;
            case 4:
                destroyWallVelocityProportion = 1.35f;
                break;
            case 5:
                destroyWallVelocityProportion = 1.7f;
                break;
            case 6:
                destroyWallVelocityProportion = 1.88f;
                break;
            case 7:
                destroyWallVelocityProportion = 1.95f;
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
                destroyWallWaitTime = 3f;
                break;
            case 2:
                destroyWallWaitTime = 2.4f;
                break;
            case 3:
                destroyWallWaitTime = 1.8f;
                break;
            case 4:
                destroyWallWaitTime = 1.25f;
                break;
            case 5:
                destroyWallWaitTime = .85f;
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
                platformSizePercentage = 3.5f;
                break;
            case 3:
                platformSizePercentage = 3f;
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
                enemyBugQuantity = 5;//6
                break;
            case 2:
                enemyBugQuantity = 8;
                break;
            case 3:
                enemyBugQuantity = 10;
                break;
            case 4:
                enemyBugQuantity = 12;
                break;
            default:
                enemyBugQuantity = 6;
                break;
        }
    }

    private void SetTimeSpawnBug(int opt)
    {
        switch (opt)
        {

            case 1:
                enemyBugInstanceTime = 9f;
                break;
            case 2:
                enemyBugInstanceTime = 8f;
                break;
            case 3:
                enemyBugInstanceTime = 7f;
                break;
            case 4:
                enemyBugInstanceTime = 4.5f;
                break;
            default:
                enemyBugInstanceTime = 5.5f;
                break;
        }
    }

    private void SetEnableBugEnemy(int dificulty)
    {
        enableBugAtack = (dificulty > 0) ? true : false;
    }

    private void SetVelocityOfEnemyBug(int percentage)
    {

        switch (percentage)
        {

            case 1:
                enemyBugVelocity = 0.8f;
                break;
            case 2:
                enemyBugVelocity = 0.9f;
                break;
            case 3:
                enemyBugVelocity = 1.15f;
                break;
            case 4:
                enemyBugVelocity = 1.25f;
                break;
            default:
                enemyBugVelocity = 1f;
                break;
        }
    }

    private void SetDrainEnergyOfEnemyBug(int percentage)
    {

        switch (percentage)
        {

            case 1:
                enemyBugEnergyDrain = 0.35f;
                break;
            case 2:
                enemyBugEnergyDrain = 0.75f;
                break;
            case 3:
                enemyBugEnergyDrain = 1.2f;
                break;
            case 4:
                enemyBugEnergyDrain = 2f;
                break;
            default:
                enemyBugEnergyDrain = 0;
                break;
        }
    }

    private void SetCannonProportion(int percentage)
    {

        switch (percentage)
        {

            case 1:
                cannonPercentage = 2.8f;
                break;
            case 2:
                cannonPercentage = 3.6f;
                break;
            case 3:
                cannonPercentage = 4.8f;
                break;
            case 4:
                cannonPercentage = 5.7f;
                break;
            case 5:
                cannonPercentage = 7.7f;
                break;
            default:
                cannonPercentage = 2.2f;
                break;
        }
    }

    private void SetMinArrowFrequency(int opt)
    {

        switch (opt)
        {

            case 1:
                minArrowFrequencyTime = 5.9f;
                break;
            case 2:
                minArrowFrequencyTime = 4.8f;
                break;
            case 3:
                minArrowFrequencyTime = 3.5f;
                break;
            case 4:
                minArrowFrequencyTime = 2f;
                break;
            default:
                minArrowFrequencyTime = 7f;
                break;
        }
    }

    private void SetArrowForce(int opt)
    {
        switch (opt)
        {

            case 1:
                arrowForce = 5f;
                break;
            case 2:
                arrowForce = 6f;
                break;
            case 3:
                arrowForce = 7f;
                break;
            case 4:
                arrowForce = 8.5f;
                break;
            case 5:
                arrowForce = 10f;
                break;

            default:
                arrowForce = 5.5f;    
                break;
        }
    }
}
