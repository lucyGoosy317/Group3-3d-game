using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    GameObject player;
    GameObject gun;
    PlayerShooting playerShooting;
    GameObject graveyardPowerupManager;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("gun");
        player = GameObject.FindGameObjectWithTag("Player");
        graveyardPowerupManager = GameObject.FindGameObjectWithTag("GraveyardPowerupManager");
        playerShooting = gun.GetComponent<PlayerShooting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerShooting.InstaKill();
            graveyardPowerupManager.GetComponent<PowerupManager>().PowerupTaken();
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject,3f);
        }
    }
}
