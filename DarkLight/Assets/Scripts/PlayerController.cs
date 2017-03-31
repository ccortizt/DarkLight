
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    float moveSpeed = 6;
    private float moveVelocity;

    public float teleportDistance;
    float teleportCoolDown = 4;
    bool isTeleportInCooldown;
    float teleportCooldownCount;

    float maxDistanceTeleportedX = 4.75f;

    public float jumpHeight;
    public bool canJump;

    private bool isPlayerGrounded;
    public LayerMask whatIsGround;
    public LayerMask destroyWall;
    public float heightOffset = 0.25f;
    public float groundedHeight = 0.26f; //0.5f


    private float teleportEnergy = 3.5f;
    private float energyConsume;
    private float defaultEnergyConsume = 0.095f;
    //private float debuffEnergyConsume = 0.8f;

    public VirtualButton teleportButton;
    public VirtualButton rightButton;
    public VirtualButton leftButton;
    public VirtualButton upButton;


    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        energyConsume = defaultEnergyConsume;
        canJump = true;
        teleportCooldownCount = 0;
        isTeleportInCooldown = false;
        try
        {
            teleportButton = GameObject.FindGameObjectWithTag("TeleportButton").GetComponent<VirtualButton>();
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

        UpdateTeleportCooldown();

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

                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, 0f);
                GetComponent<PlayerEnergyController>().DecreaseEnergy(energyConsume);

            }


            if (teleportButton.isPressed && !isTeleportInCooldown)
            {

                Vector3 aux;

                if (!PlayerExceedLimits())
                {
                    //Debug.Log("initial: "+transform.position);                    
                    if (rb.velocity.normalized.y < 0)
                    {
                        aux = new Vector3(rb.velocity.normalized.x, 0f, 0f) * teleportDistance;
                        transform.position += new Vector3(rb.velocity.normalized.x, 0f, 0f) * teleportDistance;
                    }
                    else
                    {
                        aux = new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                        transform.position += new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                    }
                    //Debug.Log("final: " + transform.position);                    

                    if (aux != Vector3.zero)
                    {
                        rb.velocity = Vector3.zero;
                        canJump = false;
                        StartCoroutine(SetCanJump());

                        GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                        SetCoolDown();
                    }

                }

            }
#else

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
                
                Vector3 aux;

                if (!PlayerExceedLimits())
                {
                    //Debug.Log("initial: "+transform.position);                    
                    if (rb.velocity.normalized.y < 0)
                    {
                        aux = new Vector3(rb.velocity.normalized.x, 0f, 0f) * teleportDistance;     
                        transform.position += new Vector3(rb.velocity.normalized.x, 0f, 0f) * teleportDistance;                        
                    }
                    else
                    {
                        aux = new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                        transform.position += new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0f) * teleportDistance;
                    }
                    //Debug.Log("final: " + transform.position);                    

                    if (aux != Vector3.zero)
                    {
                        rb.velocity = Vector3.zero;
                        canJump = false;
                        StartCoroutine(SetCanJump());

                        GetComponent<PlayerEnergyController>().DecreaseEnergy(teleportEnergy);
                        SetCoolDown();
                    }                    

                }

            }
#endif
        }
        else
        {
            GetComponent<PlayerCollisionController>().EndGame("Sin energía");
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
        yield return new WaitForEndOfFrame();
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

