using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
   private IEnumerator coroutine;
   public Spawner[] spawnersArray;
   public float spawnCooldown = 2.0f;
   private int index = 0;
       void Start()
       {

           coroutine = CallSpawn(spawnCooldown);
           StartCoroutine(coroutine);
       }
   
       private IEnumerator CallSpawn(float waitTime)
       {
           while (true)
           {
               index = Random.Range (0, spawnersArray.Length);
               spawnersArray[index].Spawn();
               yield return new WaitForSeconds(waitTime);
           }
       }
}
