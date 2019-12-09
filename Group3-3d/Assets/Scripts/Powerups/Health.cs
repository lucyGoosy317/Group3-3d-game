using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    GameObject pumpkinPowerupManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pumpkinPowerupManager = GameObject.FindGameObjectWithTag("GreenCauldronPowerupManager");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.currentHealth += 50;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            pumpkinPowerupManager.GetComponent<PowerupManager>().PowerupTaken();
            Destroy(gameObject);
        }
    }
}
