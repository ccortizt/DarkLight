using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 5, 0, Space.World);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("latform"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
