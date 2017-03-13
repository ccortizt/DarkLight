﻿
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int teleportDistance;
    float teleportCoolDown = 3;
    bool isTeleportInCooldown;
    float teleportCooldownCount;

    float maxDistanceTeleportedX = 4.65f;

    float moveSpeed = 7;
    private float moveVelocity;

    public float jumpHeight;
    public bool canJump;

    private bool isPlayerGrounded;
    public LayerMask whatIsGround;
    public LayerMask destroyWall;
    float heightOffset = 0.25f;
    public float groundedHeight = 0.5f;


    private float teleportEnergy = 5;
    private float energyConsume;
    private float defaultEnergyConsume = 0.08f;
    private float debuffEnergyConsume = 0.8f;


    Rigidbody rb;

    void Start()
    {
        canJump = true;
        energyConsume = defaultEnergyConsume;
        rb = GetComponent<Rigidbody>();
        teleportCooldownCount = 0;
        isTeleportInCooldown = false;

    }

    void FixedUpdate()
    {

        if (CheckPlayerIsGrounded())
        {
            isPlayerGrounded = true;
        }
        else
        {
            isPlayerGrounded = false;
        }

    }

    void Update()
    {

        moveVelocity = 0f;

        SetTeleportCooldownIndicator();

        UpdateTeleportCooldown();

        if (PlayerHasEnoughEnergy())
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveVelocity = moveSpeed;
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveVelocity = -moveSpeed;
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            }

            GetComponent<Rigidbody>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody>().velocity.y, 0f);

            if (Input.GetKey(KeyCode.UpArrow) && isPlayerGrounded && canJump)
            {

                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, 0f);
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);

            }


            if (Input.GetKey(KeyCode.Space) && !isTeleportInCooldown)
            {
                //Debug.Log(transform.position.x + rb.velocity.normalized.x * teleportDistance);
                if (!PlayerExceedLimits())
                {

                    if (rb.velocity.normalized.y < 0)
                    {
                        transform.position += new Vector3(rb.velocity.normalized.x, 0f, 0f) * teleportDistance;
                    }
                    else
                    {
                        transform.position += new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                    }

                    rb.velocity = Vector3.zero;
                    canJump = false;
                    StartCoroutine(SetCanJump());

                    GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                    SetCoolDown();

                }

            }

        }
        else
        {
            GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "Sin energia";
            GameObject.FindGameObjectWithTag("Restart").transform.Find("Button").gameObject.SetActive(true);
        }

    }

    private void SetCoolDown()
    {
        teleportCooldownCount = teleportCoolDown;
        isTeleportInCooldown = true;

    }
    
    private void UpdateTeleportCooldown()
    {
        if (teleportCooldownCount > 0 && isTeleportInCooldown)
        {
            teleportCooldownCount -= Time.deltaTime;
        }
        else if (teleportCooldownCount <= 0)
        {
            isTeleportInCooldown = false;
        }
    }

    private void SetTeleportCooldownIndicator()
    {
        if (isTeleportInCooldown)
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<Image>().color = Color.gray;
        else
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<Image>().color = Color.green;
    }

    private bool PlayerHasEnoughEnergy()
    {
        return GetComponent<PlayerEnergyController>().GetEnergyLevel() > 0;
    }

    private bool PlayerExceedLimits()
    {
        return transform.position.x + rb.velocity.normalized.x * teleportDistance < -maxDistanceTeleportedX || transform.position.x + rb.velocity.normalized.x * teleportDistance > maxDistanceTeleportedX;
    }

    public IEnumerator SetCanJump()
    {
        yield return new WaitForFixedUpdate();
        canJump = true;

    }

    public bool CheckPlayerIsGrounded()
    {

        Vector3 leftSide = new Vector3(transform.position.x - 0.3f, transform.position.y + heightOffset, transform.position.z);
        Vector3 rightSide = new Vector3(transform.position.x + 0.3f, transform.position.y + heightOffset, transform.position.z);
        Vector3 midSide = new Vector3(transform.position.x , transform.position.y + heightOffset, transform.position.z);

        if (Physics.Raycast(leftSide, Vector3.down, groundedHeight + heightOffset, whatIsGround) || Physics.Raycast(rightSide, Vector3.down, groundedHeight + heightOffset, whatIsGround) || Physics.Raycast(midSide, Vector3.down, groundedHeight + heightOffset, whatIsGround) || Physics.Raycast(leftSide, Vector3.down, groundedHeight + heightOffset, destroyWall) || Physics.Raycast(rightSide, Vector3.down, groundedHeight + heightOffset, destroyWall) || Physics.Raycast(midSide, Vector3.down, groundedHeight + heightOffset, destroyWall))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}

