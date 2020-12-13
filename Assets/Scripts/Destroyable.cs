using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private float health = 100;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = Resources.Load<ParticleSystem>("uderzenie");
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy();
    }

    private void Destroy()
    {
        Points.points += 1;
        Destroy(gameObject);
        particleSystem.Play();

    }

    private void OnCollisionEnter(Collision other)
    {
        other.collider.GetComponent<PlayerController>();
        Debug.Log("Koniec gry");
    }
}