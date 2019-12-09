using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    [Header("Player display life")]
    public int healthAmount;
    private GameObject playerTextObject;
    private Text playerLifeDisplay;
    //[Header("Player")]
    private charController player;
    private bool isAlive;
    private Animator playerOuchies;
    [Header("Player SFX")]
    private AudioSource playerSounds;
    public AudioClip playerGettingHit;
    public AudioClip playerDying;



    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        playerSounds = GetComponent<AudioSource>();
        player = gameObject.GetComponent<charController>();
        playerTextObject = GameObject.FindGameObjectWithTag("currenthealth");
        playerLifeDisplay = playerTextObject.GetComponent<Text>();
        playerOuchies = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Health Amount:"+ healthAmount);
        if (isAlive == false)
        {
            playerLifeDisplay.text = healthAmount.ToString();
            
            return;
        }
        playerLifeDisplay.text = healthAmount.ToString();
        //if (healthAmount <= 0)
          //  Death();
       
        
    }


    public void takeDamage(int damage){
        healthAmount -= damage;
        StartCoroutine(playGotHitReaction());
        if (healthAmount<=0)
        {
            
            Death();
        }
    }

    void Death()
    {
        playerOuchies.SetInteger("condition",5);
        isAlive = false;
        StartCoroutine(playerGettingHitSFX());
        player.isDead(false);
    }
    public int getPlayerHealth()
    {
        return healthAmount;
    }
    public bool getPlayerIsAlive()
    {
        return isAlive;
    }

    IEnumerator playerGettingHitSFX()
    {
        playerSounds.clip = playerDying;
        playerSounds.Play();
        yield return new WaitForSeconds(10f);
       // playerSounds.Stop();
    }


    IEnumerator playGotHitReaction()
    {
        playerOuchies.SetInteger("condition", 4);
        playerSounds.clip = playerGettingHit;
        playerSounds.Play();
        yield return new WaitForSeconds(.3f);
        playerSounds.Stop();
    }
}
