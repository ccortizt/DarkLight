﻿
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 4.5f;
    private float moveVelocity;

    public float teleportDistance;
    float teleportCoolDown = 3.8f;
    
    bool isTeleportInCooldown;
    float teleportCooldownCount;

    float teleportSparkCoolDown = 30;
    bool isSparkInCooldown;
    float sparkCooldownCount;

    float shieldCoolDown = 8.5f;

    bool isShieldInCooldown;
    float shieldCooldownCount;

    float maxDistanceTeleportedX = 4.75f;

    public float jumpHeight;
    public float escapeJumpHeight;
    public bool canJump;

    private bool isPlayerGrounded;
    public LayerMask whatIsGround;
    public LayerMask destroyWall;
    public float heightOffset = 0.25f;
    public float groundedHeight = 0.26f; //0.5f


    private float teleportEnergy = 3.6f;
    private float sparkEscapeEnergy = 15f;
    private float energyConsume;
    private float defaultEnergyConsume = 0.08f;

    private float shieldEnergy = 3f;

    public VirtualButton teleportButton;
    public VirtualButton shieldButton;
    public VirtualButton escapeJumpButton;
    public VirtualButton rightButton;
    public VirtualButton leftButton;
    public VirtualButton upButton;
    
    
    Rigidbody rb;
    
    void Start()
    {

        ResetButtons();

        rb = GetComponent<Rigidbody>();
        energyConsume = defaultEnergyConsume;
        canJump = true;
        teleportCooldownCount = 0;
        sparkCooldownCount = 0;
        shieldCooldownCount = 0;
        isTeleportInCooldown = false;
        isSparkInCooldown = false;
        isShieldInCooldown = false;
        AccessToJoyPad();      

    }

    public void AccessToJoyPad()
    {
        try
        {
            teleportButton = GameObject.FindGameObjectWithTag("TeleportButton").GetComponent<VirtualButton>();
            shieldButton = GameObject.FindGameObjectWithTag("ShieldButton").GetComponent<VirtualButton>();
            escapeJumpButton = GameObject.FindGameObjectWithTag("EscapeButton").GetComponent<VirtualButton>();
            rightButton = GameObject.FindGameObjectWithTag("RightButton").GetComponent<VirtualButton>();
            leftButton = GameObject.FindGameObjectWithTag("LeftButton").GetComponent<VirtualButton>();
            upButton = GameObject.FindGameObjectWithTag("UpButton").GetComponent<VirtualButton>();
        }
        catch (System.Exception e)
        {
            //GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "cant load joypad";
        }
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
        SetShieldCooldownIndicator();
        SetSparkCooldownIndicator();
        
        UpdateTeleportCooldown();
        UpdateShieldCooldown();
        UpdateSparkCooldown();

        if (PlayerHasEnoughEnergy())
        {

#if UNITY_ANDROID
            
            if (rightButton.isPressed)
            {
                moveVelocity = moveSpeed;
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            }

            if (leftButton.isPressed)
            {
                moveVelocity = -moveSpeed;
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            }

            GetComponent<Rigidbody>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody>().velocity.y, 0f);
            
            if (upButton.isPressed && isPlayerGrounded && canJump)
            {
                ReproduceJumpEffect();
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, 0f);
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);

            }


            if (teleportButton.isPressed && !isTeleportInCooldown)
            {

                Vector3 aux;

                if (!PlayerExceedLimits())
                {
                    //Debug.Log("initial: "+transform.position);                    
                    if (rb.velocity.normalized.y <= 0)
                    {
                        aux = new Vector3(rb.velocity.normalized.x, 1f, 0f) * teleportDistance;
                        transform.position += new Vector3(rb.velocity.normalized.x, 1f, 0f) * teleportDistance;
                    }
                    else
                    {
                        aux = new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                        transform.position += new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                    }
                    //Debug.Log("final: " + transform.position);                    

                    if (aux != Vector3.zero)
                    {
                        ReproduceTeleportEffect();
                        rb.velocity = Vector3.zero;
                        canJump = false;
                        StartCoroutine(SetCanJump());

                        GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                        SetCoolDown();
                    }

                }

            }
           
            if (escapeJumpButton.isPressed && HasEnoughSparkEnergy() && !isSparkInCooldown)
            {
                GetComponent<PlayerEnergyController>().DecreaseEnergy(sparkEscapeEnergy);
                transform.position += new Vector3(0, escapeJumpHeight, 0);
                SetSparkCoolDown();
            }
           
            if (shieldButton.isPressed && !isShieldInCooldown)
            {
                GetComponent<PlayerEnergyController>().DecreaseEnergy(shieldEnergy);
                GetComponent<SphereCollider>().enabled = true;
                transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                SetShieldCoolDown();
                StartCoroutine(DeactivateShield());
                
            }

#else

            if (Input.GetAxisRaw("Horizontal") > 0.2f)
            {
                moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            }

            if (Input.GetAxisRaw("Horizontal") < -0.2f)
            {
                moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);               
            }

            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    moveVelocity = moveSpeed;
            //    GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            //}

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    moveVelocity = -moveSpeed;
            //    GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);
            //}

            GetComponent<Rigidbody>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody>().velocity.y, 0f);
            
            if (Input.GetKey(KeyCode.UpArrow) && isPlayerGrounded && canJump)
            {

                ReproduceJumpEffect();
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, 0f);
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);

            }

            if (Input.GetKey(KeyCode.Space) && !isTeleportInCooldown)
            {
                
                Vector3 aux;

                if (!PlayerExceedLimits())
                {
                    //Debug.Log("initial: "+transform.position);                    
                    if (rb.velocity.normalized.y <= 0)
                    {
                        aux = new Vector3(rb.velocity.normalized.x, 1f, 0f) * teleportDistance;     
                        transform.position += new Vector3(rb.velocity.normalized.x, 1f, 0f) * teleportDistance;                        
                    }
                    else
                    {
                        aux = new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                        transform.position += new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                    }
                    //Debug.Log("final: " + transform.position);                    

                    if (aux != Vector3.zero)
                    {
                        ReproduceTeleportEffect();
                        rb.velocity = Vector3.zero;
                        canJump = false;
                        StartCoroutine(SetCanJump());

                        GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                        SetCoolDown();
                    }                    

                }

            }

            if (Input.GetKeyDown(KeyCode.V) && HasEnoughSparkEnergy() && !isSparkInCooldown)
            {
                GetComponent<PlayerEnergyController>().DecreaseEnergy(sparkEscapeEnergy);
                transform.position += new Vector3(0, escapeJumpHeight, 0);
                SetSparkCoolDown();
            }
            
            if (Input.GetKeyDown(KeyCode.C) && !isShieldInCooldown)
            {
                GetComponent<PlayerEnergyController>().DecreaseEnergy(shieldEnergy);
                GetComponent<SphereCollider>().enabled = true;
                transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                StartCoroutine(DeactivateShield());
                SetShieldCoolDown();
            }
#endif

        }
        else
        {
            GetComponent<PlayerCollisionController>().EndGame("Sin energía");
        }

    }

    private void UpdateSparkCooldown()
    {
        if (sparkCooldownCount > 0 && isSparkInCooldown)
        {
            sparkCooldownCount -= Time.deltaTime;
        }
        else if (sparkCooldownCount <= 0)
        {
            isSparkInCooldown = false;
        }
    }

    private void SetShieldCoolDown()
    {
        shieldCooldownCount = shieldCoolDown;
        isShieldInCooldown = true;
    }
    private void SetSparkCoolDown()
    {
        
        sparkCooldownCount = teleportSparkCoolDown;
        isSparkInCooldown = true;
    }

    private void SetCoolDown()
    {
        teleportCooldownCount = teleportCoolDown;
        isTeleportInCooldown = true;
    }

    private void UpdateShieldCooldown()
    {
        if (shieldCooldownCount > 0 && isShieldInCooldown)
        {
            shieldCooldownCount -= Time.deltaTime;
        }
        else if (shieldCooldownCount <= 0)
        {
            isShieldInCooldown = false;
        }
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

    private void SetShieldCooldownIndicator()
    {
        if (isShieldInCooldown)
            GameObject.FindGameObjectWithTag("Shield").GetComponent<Image>().color = Color.gray;
        else
            GameObject.FindGameObjectWithTag("Shield").GetComponent<Image>().color = Color.blue;
    }

    private void SetSparkCooldownIndicator()
    {
        if (HasEnoughSparkEnergy() && !isSparkInCooldown)
            GameObject.FindGameObjectWithTag("Spark").GetComponent<Image>().color = Color.yellow;
        else
            GameObject.FindGameObjectWithTag("Spark").GetComponent<Image>().color = Color.grey;
    }

    private bool HasEnoughSparkEnergy()
    {
        return GetComponent<PlayerEnergyController>().GetEnergyLevel() > 30;
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
        yield return new WaitForEndOfFrame();
        canJump = true;
    }

    public bool CheckPlayerIsGrounded()
    {

        Vector3 leftSide = new Vector3(transform.position.x - 0.2f, transform.position.y + heightOffset, transform.position.z);
        Vector3 rightSide = new Vector3(transform.position.x + 0.2f, transform.position.y + heightOffset, transform.position.z);
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

    private void ResetButtons()
    {
        try
        {
            GameObject.FindGameObjectWithTag("LeftButton").GetComponent<VirtualButton>().ButtonOff();
            GameObject.FindGameObjectWithTag("RightButton").GetComponent<VirtualButton>().ButtonOff();
            GameObject.FindGameObjectWithTag("UpButton").GetComponent<VirtualButton>().ButtonOff();
            GameObject.FindGameObjectWithTag("TeleportButton").GetComponent<VirtualButton>().ButtonOff();
            GameObject.FindGameObjectWithTag("ShieldButton").GetComponent<VirtualButton>().ButtonOff();
        }
        catch (System.Exception e)
        {
        }
        
    }

    private void ReproduceJumpEffect()
    {
        GetComponentInChildren<VFXController>().PlayEffect();
    }

    private void ReproduceTeleportEffect()
    {
        transform.FindChild("LightningHit").GetComponent<VFXController>().PlayEffect();
    }

    IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(5);
        GetComponent<SphereCollider>().enabled = false;
    }

}