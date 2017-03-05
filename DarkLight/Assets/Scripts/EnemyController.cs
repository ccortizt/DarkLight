using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController: MonoBehaviour{

    public float moveSpeed;
    void Update()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * moveSpeed;
    }
}