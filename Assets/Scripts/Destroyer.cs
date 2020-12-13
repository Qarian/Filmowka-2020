using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroyable com = other.GetComponent<Destroyable>();
        if (com)
            com.DealDamage(9999999);
    }
}
