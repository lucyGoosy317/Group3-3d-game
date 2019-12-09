using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManage : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject DeathMenu;
    GameObject PlayerStatus;
    private string playerString = "Player";
    private playerHealth playerHealthChecker;
    private string deathMenu = "deathmenu";

    
    private GameObject restartlvlInDeathMenu;
    
    
    void Awake()
    {
        restartlvlInDeathMenu = GameObject.FindGameObjectWithTag("restartDeath");
    

        PlayerStatus = GameObject.FindGameObjectWithTag(playerString);
        playerHealthChecker = PlayerStatus.GetComponent<playerHealth>();
        DeathMenu = GameObject.FindGameObjectWithTag(deathMenu);
        DeathMenu.SetActive(false);
      
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (playerHealthChecker.getPlayerIsAlive() == false)
        {
            DeathMenu.SetActive(true);
        }
      
    }
}
