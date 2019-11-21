using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Array of enemies

    public GameObject[] enemyList;
    public Vector3 spawnValues;
    public GameObject spawnerPos;

    public float spawnWait;
    public int startWait;
    public float mostWait;
    public float minWait;
    public bool stop;
    public int maxEnemiesSpawned = 50;
    public int enemyCounter = 0;
    int randEnemies;


    void Start()
    {
        startWait = 1;
        spawnWait = 10;
        spawnWait = Random.Range(minWait, mostWait);

        //spawnWait = Random.Range(minWait, mostWait);
        //StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter!=maxEnemiesSpawned) {
        
            StartCoroutine(spawner());
        }
    }

    IEnumerator spawner()
    {
       yield return new WaitForSeconds (startWait);
    //endless enemies 
       while (enemyCounter!=maxEnemiesSpawned)
      {
         randEnemies = Random.Range(0,0);
        //find out where the enemy is gonna be spawned at
        Vector3 spawnPosition = spawnerPos.gameObject.transform.position;//new Vector3(Random.Range(-spawnValues.x,spawnValues.x),1, Random.Range(-spawnValues.z, spawnValues.z));
    //spawn the enemy
        Instantiate(enemyList[randEnemies], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
     //Instantiate(items[randEnemies], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

    //how long it waits to spawn a new enemy
       enemyCounter++;
    // Debug.Log("Enemies spawned: "+enemyCounter);
       yield return new WaitForSeconds(spawnWait);
    }
     }

}
