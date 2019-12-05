using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public Vector3 center;
    public Vector3 size;
    public GameObject[] Powerups;
    public float spawnTime = 10f;
    public int maxPowerups = 1;

    int powerupCount = 0;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (powerupCount < maxPowerups && timer > spawnTime)
        {
            SpawnPowerup();
        }
    }

    public void SpawnPowerup()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x /2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        int spawnPointIndex = Random.Range(0, Powerups.Length);
        Debug.Log(powerupCount);
        Debug.Log(maxPowerups);
        if (powerupCount < maxPowerups)
        {
            timer = 0;
            powerupCount++;
            Instantiate(Powerups[spawnPointIndex], pos, Quaternion.identity);
        }
    }

    public void PowerupTaken()
    {
        powerupCount--;
        //Debug.Log(powerupCount);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition + center,size);
    }
}
