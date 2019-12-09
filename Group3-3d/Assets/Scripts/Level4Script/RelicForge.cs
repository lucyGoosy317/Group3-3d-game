using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicForge : MonoBehaviour
{
    public static bool playerRelicIsForged1;
    public static bool playerRelicIsForged2;
    public static bool playerRelicIsForged3;
    public static bool playerRelicIsForged4;

    private void OnTriggerEnter(Collider player)
    {
        if (gameObject.name == "Fire1" && player.gameObject.tag == "Player")
        {
            Debug.Log("Player has picked up: " + gameObject.name);
            playerRelicIsForged1 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Fire2" && player.gameObject.tag == "Player")
        {
            playerRelicIsForged2 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Fire3" && player.gameObject.tag == "Player")
        {
            playerRelicIsForged3 = true;
            Destroy(gameObject);
        }
        if (gameObject.name == "Fire4" && player.gameObject.tag == "Player")
        {
            playerRelicIsForged4 = true;
            Destroy(gameObject);
        }
    }


}
