using System;
using System.Collections;
using UnityEngine;

public class DarkPlayerController : MonoBehaviour
{

    int teleportDistance;

    float flashCoolDown = 3;
    bool isInCoolDown;
    float flashCoolDownCount;

    float moveSpeed =5;

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
                SetCoolDown();
            }
            else
            {
                rb.MovePosition(transform.position - transform.right * Time.deltaTime * moveSpeed);
            }


        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {

                transform.position = transform.position + teleportDistance * transform.right;
                SetCoolDown();
            }
            else
            {
                rb.MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed);
            }


        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {
                transform.position = transform.position + teleportDistance * transform.forward;
                SetCoolDown();
            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
            }


        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.Space) && !isInCoolDown)
            {
                transform.position = transform.position - teleportDistance * transform.forward;
                SetCoolDown();
            }
            else
            {
                rb.MovePosition(transform.position - transform.forward * Time.deltaTime * moveSpeed);
            }

        }

    }

    private void SetCoolDown()
    {
        flashCoolDownCount = flashCoolDown;
        isInCoolDown = true;

    }

}
