using System;
using System.Collections.Generic;
using UnityEngine;
public class LevelDifficultyController: MonoBehaviour{

    int courrentlevelDifficulty;

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

    float destroyWallVelocityProportion;

    public float DestroyWallVelocityProportion
    {
        get { return destroyWallVelocityProportion; }
        set { destroyWallVelocityProportion = value; }
    }

    int enemyProportion;
    int enemyVelocityProportion;


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
                SetDestroyWallVelocityProp(0);
                
                break;
            case 2:
                SetEnergyRange(1);
                SetPlatformRange(0);
                SetDestroyWallProportion(1);
                SetDestroyWallVelocityProp(0);                
                break;
            case 3:
                SetEnergyRange(1);
                SetPlatformRange(1);
                SetDestroyWallProportion(2);
                SetDestroyWallVelocityProp(0);                
                break;
            case 4:
                SetEnergyRange(1);
                SetPlatformRange(1);
                SetDestroyWallProportion(3);
                SetDestroyWallVelocityProp(0);
                break;
            case 5:
                SetEnergyRange(0);
                SetPlatformRange(0);
                SetDestroyWallProportion(4);
                SetDestroyWallVelocityProp(0);
                break;
            case 6:
                SetEnergyRange(1);
                SetPlatformRange(0);
                SetDestroyWallProportion(4);
                SetDestroyWallVelocityProp(0);
                //enemy
                break;
            case 7:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallVelocityProp(1);
                //enemy
                break;
            case 8:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallVelocityProp(2);
                //enemy
                break;
            case 9:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallVelocityProp(3);
                //enemy
                break;
            case 10:
                SetEnergyRange(0);
                SetPlatformRange(1);
                SetDestroyWallProportion(4);
                SetDestroyWallVelocityProp(4);
                //enemy
                break;
            default:
                SetEnergyRange(0);
                SetPlatformRange(0);
                SetDestroyWallProportion(-1);
                SetDestroyWallVelocityProp(2);                
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
            default:
                destroyWallVelocityProportion = 0;
                break;
        }
    }

}
