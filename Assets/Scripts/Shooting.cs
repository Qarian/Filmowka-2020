using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private float damage = 20;

    private void Start()
    {
        if (origin is null)
            origin = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    private void Shoot()
    {
        Vector3 pos = transform.position;
        RaycastHit hit;
        if (!Physics.Raycast(pos, transform.forward, out hit))
            return;
        
        Debug.DrawLine(pos, hit.point, Color.red, 0.3f);

        Destroyable other = hit.collider.GetComponent<Destroyable>();
        other.DealDamage(damage);
    }
}
