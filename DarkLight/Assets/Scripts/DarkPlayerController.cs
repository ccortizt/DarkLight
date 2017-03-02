using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DarkPlayerController : MonoBehaviour
{

    int teleportDistance;

    float flashCoolDown = 3;
    bool isInCoolDown;
    float flashCoolDownCount;

    float moveSpeed = 6;
    float teleportEnergy = 5;


    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flashCoolDownCount = 0;
        teleportDistance = 4;
        isInCoolDown = false;
    }

    void Update()
    {


        if (isInCoolDown)
            GameObject.Find("PlayerHUD").transform.FindChild("LifePanel/SkillPanel/Teleport").GetComponent<Image>().color = Color.grey;
        else
            GameObject.Find("PlayerHUD").transform.FindChild("LifePanel/SkillPanel/Teleport").GetComponent<Image>().color = Color.green;


        if (flashCoolDownCount > 0 && isInCoolDown)
        {
            flashCoolDownCount -= Time.deltaTime;
        }
        else if (flashCoolDownCount <= 0)
        {
            isInCoolDown = false;
        }


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
                GetComponent<PlayerEnergyController>().DecreaseEnergy();
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
                GetComponent<PlayerEnergyController>().DecreaseEnergy();
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
                GetComponent<PlayerEnergyController>().DecreaseEnergy();
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
                GetComponent<PlayerEnergyController>().DecreaseEnergy();
            }

        }

    }

    private void SetCoolDown()
    {
        flashCoolDownCount = flashCoolDown;
        isInCoolDown = true;

    }

}
