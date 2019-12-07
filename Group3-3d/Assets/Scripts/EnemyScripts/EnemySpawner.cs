using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //Array of enemies

    [Header("Enemies for the spawner to spawn")]
    public GameObject[] enemyList;  //used to store enemy objects
    public int enemyIndexMin; //Used to determine if all you want the 0 index of the list or starting at a certain index
    public int enemyIndexSizeMax;  //used to determine the max range when spawning the list
    private int randEnemies; //used to store a random value from the index to spawn enemy


    [Header("Max and Min of enemies to be created during a wave attack")]
    public int maxSpawnNum; //max amount in wave
    public int minSpawnNum; //min amount in wave
    private int RandomAmountOfEnemies; //will be the range of max and min

    [Header("Time between Spawning")]
    public float minSpawnTime; //waiting for seconds min between each enemy spawned
    public float maxSpawnTime;  //waiting for seconds max between each enemy spawned

    [Header("Time between Waves")]
    public float minSpawnWave; //wait for seconds min between waves
    public float maxSpawnWave; //wait for seconds max between waves

    //[Header("Time to start")]
    //public float startWaveTime;
    //public float spawnRepeatRate;

    [Header("Stop Spawning")]
    public bool StopSpawning; //stop spawning;
    private string spawnerMethodName = "EndlessWaves";

    [Header("Max amount of enemies spawned at a time")]
    public int maxAmountSpawn;
    private int totalEnemies;

    string enemyTag = "Enemy";
    public IEnumerator spawn; // in order to stop a coroutine must assign it
            


    void Start()
    {
        spawn = EndlessWaves();
        StopSpawning = false;
        StartCoroutine(spawn);
        
    }

    void Update()
    {
        //stop spawning
        if (StopSpawning) {
            //Debug.Log("Stopped spawning");
            StopCoroutine(spawn);
        }

        


    }


    //Coroutine that will allow spawning event
    public IEnumerator EndlessWaves()
    {
        
        
            //Debug.Log("Start Spawning");
            while (StopSpawning != true) {
            //totalEnemies = findAllEnemies();
           //Debug.Log("Total enemies:" + totalEnemies);
           
                // Debug.Log("Starting to spawn");
                RandomAmountOfEnemies = Random.Range(minSpawnNum, maxSpawnNum);
                //Debug.Log("Amount of enemies to be created: " + RandomAmountOfEnemies);
                for (int i = 0; i < RandomAmountOfEnemies; i++)
                {
                    //Get a different enemy from the list every iteration
                    randEnemies = Random.Range(enemyIndexMin, enemyIndexSizeMax);
                    //  Debug.Log("Who is being Created: " + enemyList[randEnemies].name);
                    //note to self, make sure on awake the enemy gathers everything it needs before instantiate, such as destination, and other items need...find by tag
                    Instantiate(enemyList[randEnemies], gameObject.transform.position, gameObject.transform.rotation);

                    //Space the enemies out between loop, so they dont stack on each other
                    yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
                }
                //Time between waves
                yield return new WaitForSeconds(Random.Range(minSpawnWave, maxSpawnWave));
            }
            
    }


    //starting spawning again
    public void continueToSpawn(bool startSpawning)
    {
        StopSpawning = startSpawning;
        StartCoroutine(spawn);
    }

    //stop spawing
    public void stopSpawning(bool stopSpawning)
    {
        StopSpawning = stopSpawning;
        StopCoroutine(spawn);
    }

    public void pauseSpawn()
    {
        
    }

    public int findAllEnemies()
    {
        
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);
            //Debug.Log("Total enemies found: "+ allEnemies.Length);
            int totalEnemiestemp = allEnemies.Length;
            return totalEnemiestemp;
        

    }

}
