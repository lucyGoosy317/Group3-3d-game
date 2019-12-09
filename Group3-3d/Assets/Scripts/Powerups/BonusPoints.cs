using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    GameObject player;
    PlayerShooting playerShooting;
    GameObject cauldronPowerupManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cauldronPowerupManager = GameObject.FindGameObjectWithTag("RedCauldronPowerupManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            ScoreManager.Bonus();
            Destroy(gameObject);
            cauldronPowerupManager.GetComponent<PowerupManager>().PowerupTaken();
        }
    }
}
