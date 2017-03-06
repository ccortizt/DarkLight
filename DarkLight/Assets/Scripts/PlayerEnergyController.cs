using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyController : MonoBehaviour {


    private float energyLevel;
    private float initialEnergyLevel = 100;

    private Image energyBar;

    

	void Start () {

        energyBar = GameObject.Find("PlayerHUD").transform.FindChild("LifePanel/EnergyPanel/Panel/Energy").GetComponent<Image>();
        energyLevel = initialEnergyLevel;
	}

    public void AddEnergy(float quantity)
    {
        if (energyLevel < initialEnergyLevel)
        {
            if (energyLevel + quantity > initialEnergyLevel)
                energyLevel = initialEnergyLevel;
            else
                energyLevel += quantity;

            UpdateEnergyBar();
        }
    }

    public void DecreaseEnergy(float quantity)
    {
        if (energyLevel > 0)
        {
            energyLevel -= quantity;

            UpdateEnergyBar();
        }
    }
	
	private void UpdateEnergyBar ()
    {
        energyBar.fillAmount = (float)energyLevel / (float)initialEnergyLevel;
        Debug.Log("energy: " + energyLevel);

    }

    public float GetEnergyLevel()
    {
        return energyLevel;
    }
}
