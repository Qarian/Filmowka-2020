using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int index = 0;
    public GameObject[] EnemyPrefab;
    public void Spawn()
    {
        index = Random.Range (0, EnemyPrefab.Length);
        Transform.Instantiate(EnemyPrefab[index]);
    }
}
