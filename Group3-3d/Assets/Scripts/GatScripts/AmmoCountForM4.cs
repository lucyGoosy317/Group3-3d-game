using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCountForM4 : AmmoCount
{
    // Start is called before the first frame update
    void Start()
    {
        maxAmountInMag = 30;
        countBullets = 0;
        bulletInMag = 30;
        totalAmountOfBullets = 120;
        shootingGat = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentWeaponAmmoCount.AmmoutCount = bulletInMag;

        updateDisplay();
        if (Input.GetAxis("Fire1") > 0 && shootingGat)
        {
            StartCoroutine(GunShootingDisplayUpdate());
            fireBullet();
        }
        reload();
    }
}
