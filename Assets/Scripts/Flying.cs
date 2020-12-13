using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    
    private void Update()
    {
        transform.LookAt(PlayerController.playerPos);
        transform.LookAt(PlayerController.playerPos);
        transform.Translate(transform.forward * (Time.deltaTime * speed));
    }
}
