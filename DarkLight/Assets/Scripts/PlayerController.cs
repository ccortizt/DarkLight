using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour{
 
    int teleportDistance;

    float flashCoolDown = 3;
    bool isInCoolDown;
    float flashCoolDownCount;

    float moveSpeed = 7;
    float teleportEnergy = 5;

    private float energyConsume;
    private float defaultEnergyConsume = 0.08f;
    private float debuffEnergyConsume = 0.8f;


    Rigidbody rb;


    void Start()
    {
        energyConsume = defaultEnergyConsume;
        rb = GetComponent<Rigidbody>();
        flashCoolDownCount = 0;
        teleportDistance = 4;
        isInCoolDown = false;
    }

    void Update()
    {


        if (isInCoolDown)
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<Image>().color = Color.gray;
        //GameObject.Find("PlayerHUD").transform.FindChild("LifePanel/SkillPanel/Teleport").GetComponent<Image>().color = Color.gray;
        else
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<Image>().color = Color.green;
            //GameObject.Find("PlayerHUD").transform.FindChild("LifePanel/SkillPanel/Teleport").GetComponent<Image>().color = Color.green;


        if (flashCoolDownCount > 0 && isInCoolDown)
        {
            flashCoolDownCount -= Time.deltaTime;
        }
        else if (flashCoolDownCount <= 0)
        {
            isInCoolDown = false;
        }

        if (GetComponent<PlayerEnergyController>().GetEnergyLevel() > 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
                {
                    transform.position = transform.position - teleportDistance * transform.right;
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                    SetCoolDown();
                }
                else
                {
                    rb.MovePosition(transform.position - transform.right * Time.deltaTime * moveSpeed);
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
                }


            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
                {

                    transform.position = transform.position + teleportDistance * transform.right;
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                    SetCoolDown();
                }
                else
                {
                    rb.MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed);
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
                }


            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
                {
                    transform.position = transform.position + teleportDistance * transform.forward;
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                    SetCoolDown();
                }
                else
                {
                    rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
                }


            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
                {
                    transform.position = transform.position - teleportDistance * transform.forward;
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                    SetCoolDown();
                }
                else
                {
                    rb.MovePosition(transform.position - transform.forward * Time.deltaTime * moveSpeed);
                    GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
                }

            }
        }
        
    }

    private void SetCoolDown()
    {
        flashCoolDownCount = flashCoolDown;
        isInCoolDown = true;

    }

    public void PunishmentEnergyConsumption()
    {
        GetComponent<PlayerEnergyController>().DecreaseEnergy(GetComponent<PlayerEnergyController>().GetEnergyLevel() / 100 * 75);
    }

}

