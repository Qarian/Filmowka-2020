using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private ParticleSystem particleSystem;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy();
    }

    private void Destroy()
    {
        Points.points += 1;
        
        particleSystem.transform.SetParent(null);
        particleSystem.Play();
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        other.collider.GetComponent<PlayerController>();
        Debug.Log("Koniec gry");
    }
}