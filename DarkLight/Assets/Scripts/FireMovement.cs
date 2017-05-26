using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{

    float velocity = 0.05f;   
    bool isMovementEnabled = true;

    void Start()
    {
        StartCoroutine(RandomMovement());
    }
    void Update()
    {
        if (transform.position.x >= 4.4f || transform.position.x <= -4.4f)
        {
            velocity *= -1;
        }

        if(isMovementEnabled)
            transform.position = transform.position + new Vector3(velocity, 0, 0);

    }

    public IEnumerator RandomMovement()
    {
               
        for (int i = 0; i < 50; i++)
        {
            
            isMovementEnabled = false;
            yield return new WaitForSeconds(Random.Range(0.5f,3));
            isMovementEnabled = true;            
            yield return new WaitForSeconds(Random.Range(3,10));

            if (!isInRangeOfPlayer())
            {
                break;
            }
            
        }
    }

    public void SetVelocity(float value)
    {
        velocity = value;
    }

    public float GetVelocity()
    {
        return velocity;
    }

    private bool isInRangeOfPlayer()
    {
        return gameObject.transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y > -5;

    }
}
