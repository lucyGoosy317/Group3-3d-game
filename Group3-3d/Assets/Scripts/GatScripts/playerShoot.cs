﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
   // public GameObject[] childObjects;
    public GameObject barrelLocation;
    public AudioSource gunNoises;
    public AudioClip gunShot;
    public AudioClip gunEmpty;
    bool shootingGat;
    bool gatIsEmpty;
    
  
    // Start is called before the first frame update
    void Start()
    {
        gunNoises = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shootingGat = true;
        gatIsEmpty = true;

    }

    // Update is called once per frame
    void Update()
    {
        findBarrelLocation();
        float fireTrigger = Input.GetAxis("Fire1");
        //Debug.Log(fireTrigger);
        if (fireTrigger>0 && shootingGat && currentWeaponAmmoCount.AmmoutCount > 0)
        {
            StartCoroutine(GunShootingAudio());
            Debug.Log("Fired");
            checkForHit();
        }
        if(fireTrigger>0 && gatIsEmpty &&currentWeaponAmmoCount.AmmoutCount == 0)
        {
            StartCoroutine(GunEmptyAudio());
            Debug.Log("Gun Empty");
        }
        
       
        //gunNoises.Stop();

    }
    //universal all gats will have a BarrelLocation
    void findBarrelLocation()
    {
        
        barrelLocation = GameObject.Find("BarrelLocation");
        
    }
    //testing, add if for enemy
    void checkForHit()
    {
        RaycastHit objectHit;
        Vector3 fwd = barrelLocation.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(barrelLocation.transform.TransformDirection(Vector3.forward),fwd,Color.red);
        if (Physics.Raycast(barrelLocation.transform.position, fwd, out objectHit, Mathf.Infinity))
        {
            //Hitting an enemy
            if (objectHit.collider.tag=="Enemy")
            {
                GameObject theEnemy = objectHit.collider.gameObject;
                enemyAI damagedEnemy = theEnemy.GetComponentInParent<enemyAI>();
                //AmmoCount currentWeaponDamage = GetComponentInChildren<AmmoCount>();
                if (damagedEnemy.enemyHealth>0) {
                    damagedEnemy.subtractHealth(currentWeaponAmmoCount.currentWeaponDamage);//temp damage
                    Debug.Log("I hit :" + objectHit.collider.tag);
                }
                else
                {
                    Debug.Log("Enemy is dead, cant shoot it any more");
                }
            }
            else
            { 
            Debug.Log("I hit :"+objectHit.collider.name +"Damn missed");
            }

            //Hitting a target
            if (objectHit.collider.tag=="testTarget")
            {
                Debug.Log("Damage done to target: "+currentWeaponAmmoCount.currentWeaponDamage);
            }

        }
    }
  
    IEnumerator GunShootingAudio()
    {
        shootingGat = false;
        gunNoises.PlayOneShot(gunShot);
        yield return new WaitForSeconds(gunShot.length/4);
        shootingGat = true;
    }
    IEnumerator GunEmptyAudio()
    {
        gatIsEmpty = false;
        gunNoises.PlayOneShot(gunEmpty);
        yield return new WaitForSeconds(gunEmpty.length);
        gatIsEmpty = true;
        //shootingGat = true;
    }
}