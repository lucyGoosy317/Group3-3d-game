using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayerWeapons : MonoBehaviour
{
    public Text weaponDisplayLabel;
    public List<GameObject> weapons;
    int currentWeaponValue;
    public static bool playerIsChangingWeapons;
    Dictionary<string, bool> playerHasWeapon;
    public bool playerHasM4;
    public bool playerHasAk47;
    public bool playerhasMachineGun;
    void Start()
    {
        
        currentWeaponValue = 0;
        weapons[0].SetActive(true);
        playerIsChangingWeapons = false;
        weaponDisplayLabel.text = weapons[currentWeaponValue].name;
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
        playerHasWeapon.Add(weapons[currentWeaponValue].name, true);
    }
    private void Awake()
    {
        playerHasWeapon = new Dictionary<string, bool>();
    }

    void Update()
    {
      
        rotateThroughWeaponsFwd();
        rotateThroughWeaponsBack();
    }


    void rotateThroughWeaponsFwd()
    {
        
        if (Input.GetButtonDown("RightBump") &&currentWeaponValue!=weapons.Capacity-1 &&playerHasWeapon.ContainsKey(weapons[currentWeaponValue+1].name))
        {
            if (weapons[currentWeaponValue+1] !=null)
            {
                Debug.Log("Weapon change can happen");
            }
            else
            {
                Debug.Log("Weapon change cant happen, null");
            }
            Debug.Log("Going fwd through weapons");
            weapons[currentWeaponValue].SetActive(false);
            currentWeaponValue++;
            weapons[currentWeaponValue].SetActive(true);
            weaponDisplayLabel.text = weapons[currentWeaponValue].name;

        }
       // else
        //{
          //  Debug.Log("Player does not have any other weapons to rotate through");
        //}  
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

    public void OnTriggerEnter(Collider pickedUpWeapon)
    {
       // Debug.Log("Player ran into:" + pickedUpWeapon.name);
        if (pickedUpWeapon.gameObject.name=="AK74") {
            Debug.Log("Player picked up:" + pickedUpWeapon.name);
            playerHasWeapon.Add(pickedUpWeapon.name,true);
            Destroy(pickedUpWeapon.gameObject);

        }
        if (pickedUpWeapon.gameObject.name=="MachineGun")
        {
            Debug.Log("Player picked up:" + pickedUpWeapon.name);
            playerHasWeapon.Add(pickedUpWeapon.name, true);
            Destroy(pickedUpWeapon.gameObject);
        }
    }

}
