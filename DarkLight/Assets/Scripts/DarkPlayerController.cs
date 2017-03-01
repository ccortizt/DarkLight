using System;
using System.Collections;
using UnityEngine;

public class DarkPlayerController : MonoBehaviour
{

    int teleportDistance;

    float flashCoolDown = 3;
    bool isInCoolDown;
    float flashCoolDownCount;


    void Start()
    {
        flashCoolDownCount = 0;
        teleportDistance = 4;
        isInCoolDown = false;
    }

    void Update()
    {

        if (flashCoolDownCount > 0 && isInCoolDown)
        {
            flashCoolDownCount -= Time.deltaTime;
        }
        else if (flashCoolDownCount <= 0)
        {
            isInCoolDown = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {
                transform.position = transform.position - teleportDistance * transform.right;
                SetCoolDown();
            }
            else
            {
                transform.position = transform.position - transform.right;
            }


        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {

                transform.position = transform.position + teleportDistance * transform.right;
                SetCoolDown();
            }
            else
            {
                transform.position = transform.position + transform.right;
            }


        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {
                transform.position = transform.position + teleportDistance * transform.forward;
                SetCoolDown();
            }
            else
            {
                transform.position = transform.position + transform.forward;
            }


        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {
                transform.position = transform.position - teleportDistance * transform.forward;
                SetCoolDown();
            }
            else
            {
                transform.position = transform.position - transform.forward;
            }

        }

    }

    private void SetCoolDown()
    {
        flashCoolDownCount = flashCoolDown;
        isInCoolDown = true;

    }

}
