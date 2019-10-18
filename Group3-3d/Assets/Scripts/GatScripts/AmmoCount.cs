using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoCount : MonoBehaviour
{
    public int bulletInMag;
    public int countBullets;
    public int totalAmountOfBullets;
    public int maxAmountInMag;
    public Text bulletInMagDisplay;
    public Text totalAmountOfBulletsDisplay;
    public bool shootingGat;
    public AudioClip gunShot;




    void Start()
    {
        maxAmountInMag = 100;
        countBullets = 0;
        bulletInMag = 100;
        totalAmountOfBullets = 300;
        shootingGat = true;
        
    }

    
    void Update()
    {
        currentWeaponAmmoCount.AmmoutCount = bulletInMag;
        
        updateDisplay();
        if (Input.GetAxis("Fire1") > 0 && shootingGat) {
            StartCoroutine(GunShootingDisplayUpdate());
            fireBullet();
        }
        reload();
    }

    public void updateDisplay()
    {
        bulletInMagDisplay.text = bulletInMag.ToString() + "/";
        totalAmountOfBulletsDisplay.text = totalAmountOfBullets.ToString();
    }

    public void fireBullet()
    {
        if (bulletInMag >0)
        {
            if (Input.GetAxis("Fire1")>0)
            {
                bulletInMag -= 1;
                countBullets += 1;
               
                bulletInMagDisplay.text = bulletInMag.ToString() + "/";
            }
        }
    }

    public void reload()
    {
        if (bulletInMag != maxAmountInMag)
        {

            if (totalAmountOfBullets!=0)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    if (totalAmountOfBullets>=maxAmountInMag)
                    {
                        Debug.Log("Reloading");
                        int tempAmount = countBullets;
                        totalAmountOfBullets = totalAmountOfBullets - tempAmount;
                        bulletInMag += tempAmount;
                        bulletInMagDisplay.text = bulletInMag.ToString() + "/";
                        totalAmountOfBulletsDisplay.text = totalAmountOfBullets.ToString();
                        countBullets = 0;
                    }
                    else
                    {
                        Debug.Log("Reloading remaining amount of ammo");
                        int tempAmount = totalAmountOfBullets;
                        totalAmountOfBullets = 0;
                        bulletInMag = tempAmount;
                        bulletInMagDisplay.text = bulletInMag.ToString() + "/";
                        totalAmountOfBulletsDisplay.text = totalAmountOfBullets.ToString();
                        countBullets = 0;
                    }
                    
                }

            }


        }
    }

    public IEnumerator GunShootingDisplayUpdate()
    {
        shootingGat = false;
        yield return new WaitForSeconds(gunShot.length / 4);
        shootingGat = true;
    }
}
