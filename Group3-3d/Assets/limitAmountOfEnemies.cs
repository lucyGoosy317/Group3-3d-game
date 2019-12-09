using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitAmountOfEnemies : MonoBehaviour
{
    [Header("Enemy spawning limit")]
    public GameObject enemySpawner;
    public int maxAmountEnemies;
    public int minAmountEnemies;
    private int currentAmountOfEnemies;
    GameObject[] enemies;
    private EnemySpawner spawnController;

    void Start()
    {
        spawnController = enemySpawner.GetComponent<EnemySpawner>(); 
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies != null)
        {
            currentAmountOfEnemies = enemies.Length;
            Debug.Log("currentAmount of enemies:" + currentAmountOfEnemies);
        }
        
    }


    int checkForEnemies()
    {
        GameObject.FindGameObjectsWithTag("enemy");

        int amount = enemies.Length;
        
        return amount;
    }

    void stopSpawning()
    {
        if (maxAmountEnemies<currentAmountOfEnemies)
        {
            spawnController.StopCoroutine(spawnController.spawn);
        }
    }

    void startSpawn()
    {
        if (minAmountEnemies>currentAmountOfEnemies)
        {
            spawnController.StartCoroutine(spawnController.spawn);
        }
    }
}
