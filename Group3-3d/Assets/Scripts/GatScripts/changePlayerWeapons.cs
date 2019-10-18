using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayerWeapons : MonoBehaviour
{
    public Text weaponDisplayLabel;
    public GameObject[] weapons;
    int currentWeaponValue;
    public static bool playerIsChangingWeapons;
    void Start()
    {
        currentWeaponValue = 0;
        weapons[0].SetActive(true);
        playerIsChangingWeapons = false;
        weaponDisplayLabel.text = weapons[currentWeaponValue].name;
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
    }

    void Update()
    {
      
        rotateThroughWeaponsFwd();
        rotateThroughWeaponsBack();
    }


    void rotateThroughWeaponsFwd()
    {
        
        if (Input.GetButtonDown("RightBump") &&currentWeaponValue!=weapons.Length-1)
        {
            playerIsChangingWeapons = true;
            Debug.Log("Going fwd through weapons");
            weapons[currentWeaponValue].SetActive(false);
            currentWeaponValue++;
            weapons[currentWeaponValue].SetActive(true);
            weaponDisplayLabel.text = weapons[currentWeaponValue].name;
            playerIsChangingWeapons = false;
        }  
    }

    void rotateThroughWeaponsBack()
    {
        if (Input.GetButtonDown("LeftBump") && currentWeaponValue >0)
        {
            Debug.Log("Going back through weapons");
            weapons[currentWeaponValue].SetActive(false);
            currentWeaponValue--;
            weapons[currentWeaponValue].SetActive(true);
            weaponDisplayLabel.text = weapons[currentWeaponValue].name;
        }
    }

    
}
