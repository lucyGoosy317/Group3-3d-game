using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    GameObject pumpkinPowerupManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pumpkinPowerupManager = GameObject.FindGameObjectWithTag("PumpkinPowerupManager");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.BecomeInvincible();
            Destroy(gameObject);
            pumpkinPowerupManager.GetComponent<PowerupManager>().PowerupTaken();
        }
    }
}
