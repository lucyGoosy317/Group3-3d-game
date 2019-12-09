using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject M4;
    public GameObject Ak74;
    public GameObject MachineGun;
    private RayCastShoot M4Ammo;
    private RayCastShoot Ak74Ammo;
    private RayCastShoot MachineGunAmmo;


    // Start is called before the first frame update
    void Start()
    {
        M4Ammo = M4.GetComponent<RayCastShoot>();
        Ak74Ammo = Ak74.GetComponent<RayCastShoot>();
        MachineGunAmmo = MachineGun.GetComponent<RayCastShoot>();
    }


    private void OnTriggerEnter(Collider ammoBox)
    {
        Debug.Log("a trigger");
        if (ammoBox.GetComponent<AmmoBox>()!=null) {
            Debug.Log("Found ammo");

            increaseAmmoOfWeapon(ammoBox.gameObject.tag, ammoBox.GetComponent<AmmoBox>().ammoutToFill());
            Destroy(ammoBox.gameObject);
        }


    }

    void increaseAmmoOfWeapon(string ammoBoxType,int ammountAdded)
    {

        switch (ammoBoxType)
        {
            case "m4Ammo":
                Debug.Log("m4 inc");
                M4Ammo.increaseTotalAmmo(ammountAdded);
                break;
            case "akAmmo":
                Debug.Log("ak inc");
                Ak74Ammo.increaseTotalAmmo(ammountAdded);
                break;
            case "mgAmmo":
                Debug.Log("mg inc");
                MachineGunAmmo.increaseTotalAmmo(ammountAdded);
                break;

        }


    }





}
