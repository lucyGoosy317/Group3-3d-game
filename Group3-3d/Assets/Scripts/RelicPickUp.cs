using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicPickUp : MonoBehaviour
{
    public static bool playerHasRelic1;
    public static bool playerHasRelic2;
    public static bool playerHasRelic3;
    public static bool playerHasRelic4;
    public static bool playerHasRelic5;
    public static bool playerHasAllRelics;

    private void OnTriggerEnter(Collider player)
    {
        if (gameObject.name=="Relic1" && player.gameObject.tag=="Player")
        {
            Debug.Log("Player has picked up: "+ gameObject.name);
            playerHasRelic1 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Relic2" && player.gameObject.tag == "Player")
        {
            Debug.Log("Player has picked up: " + gameObject.name);
            playerHasRelic2 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Relic3" && player.gameObject.tag == "Player")
        {
            Debug.Log("Player has picked up: " + gameObject.name);
            playerHasRelic3 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Relic4" && player.gameObject.tag == "Player")
        {
            Debug.Log("Player has picked up: " + gameObject.name);
            playerHasRelic4 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Relic5" && player.gameObject.tag == "Player")
        {
            Debug.Log("Player has picked up: " + gameObject.name);
            playerHasRelic5 = true;
            Destroy(gameObject);
        }
    }


}
