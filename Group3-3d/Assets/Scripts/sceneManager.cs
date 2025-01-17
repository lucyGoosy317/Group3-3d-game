﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    //loading levels, later will add relic items, player can only change to the next lvl 
    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("Entered Trigger of:"+ gameObject.name);
        if (gameObject.name=="GoToLevel1" && player.gameObject.tag=="Player" && RelicPickUp.playerHasRelic1)
        {
            Debug.Log("going to lvl1 from testing");
            SceneManager.LoadScene("lvl1");
            RelicPickUp.playerHasRelic1 = false;
            Debug.Log("Player has following relics: "+ RelicPickUp.playerHasRelic1 + RelicPickUp.playerHasRelic2+ RelicPickUp.playerHasRelic3+ RelicPickUp.playerHasRelic4+ RelicPickUp.playerHasRelic5);
        }
        if (gameObject.name == "GoToLevel2" && player.gameObject.tag == "Player" && RelicPickUp.playerHasRelic1)
        {
            Debug.Log("going to lvl2 from lvl1");
            SceneManager.LoadScene("lvl2");
        }
        if (gameObject.name == "GoToLevel3" && player.gameObject.tag == "Player" && RelicPickUp.playerHasRelic2)
        {
            Debug.Log("going to lvl3 from lvl2");
            SceneManager.LoadScene("lvl3");
        }
        if (gameObject.name == "GoToLevel4" && player.gameObject.tag == "Player" && RelicPickUp.playerHasRelic3)
        {
            Debug.Log("going to lvl4 from lvl3");
            SceneManager.LoadScene("lvl4");
        }
        if (gameObject.name == "GoToLevel5" && player.gameObject.tag == "Player" && RelicPickUp.playerHasRelic4)
        {
            Debug.Log("going to lvl5 from lvl4");
            SceneManager.LoadScene("lvl5");
        }
    }


    public void StartGame()
    {
        Debug.Log("Starting game in Testing Scene");
        SceneManager.LoadScene("TestingScene");
    }

    public void ExitGame()
    {
        Debug.Log("Quiting Game");
        Application.Quit();
    }
}
