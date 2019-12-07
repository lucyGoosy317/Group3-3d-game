using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayerWeapons : MonoBehaviour
{


    private string RightBumpButton = "RightBump";
    private string LeftBumpButton = "LeftBump";
    private int maxWeapons;
    private int amountOfWeapons;

    private Text weaponDisplayLabel;
    public List<GameObject> weapons;
    int currentWeaponValue;
    public static bool playerIsChangingWeapons;
    Dictionary<string, bool> playerHasWeapon;
    public bool playerHasM4;
    public bool playerHasAk47;
    public bool playerhasMachineGun;
    private GameObject FindWeaponLabel;
   


    void Start()
    {
        maxWeapons = 2;
        currentWeaponValue = 0;
        amountOfWeapons = 1;
        weapons[0].SetActive(true);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
        //playerHasWeapon.Add(weapons[currentWeaponValue].name, true);
    }
    private void Awake()
    {
        FindWeaponLabel = GameObject.FindGameObjectWithTag("weaponName");
        weaponDisplayLabel = FindWeaponLabel.GetComponent<Text>();
        //playerHasWeapon = new Dictionary<string, bool>();
    }

    void Update()
    {


        if (Input.GetButtonDown(RightBumpButton))
        {
            Debug.Log("Right bumper");
            rotateThroughWeaponsFwd();
        }
        if (Input.GetButtonDown(LeftBumpButton))
        {
            Debug.Log("Left bumper");
            rotateThroughWeaponsBack();
        }
        
    }


    void rotateThroughWeaponsFwd()
    {
        
            if (currentWeaponValue != maxWeapons)
            {
                Debug.Log("Weapon change can happen");
                weapons[currentWeaponValue].SetActive(false);
                currentWeaponValue++;
                weapons[currentWeaponValue].SetActive(true);
                weaponDisplayLabel.text = weapons[currentWeaponValue].GetComponent<RayCastShoot>().weaponType;
            }
            else
            {
                Debug.Log("Weapon change cant happen, null");
            }
         
    }

    


    void rotateThroughWeaponsBack()
    {
        Debug.Log("trying to change weapons back");
        if (Input.GetButtonDown("LeftBump") && currentWeaponValue >0)
        {
            Debug.Log("Going back through weapons");
            weapons[currentWeaponValue].SetActive(false);
            currentWeaponValue--;
            weapons[currentWeaponValue].SetActive(true);
            weaponDisplayLabel.text = weapons[currentWeaponValue].GetComponent<RayCastShoot>().weaponType;
        }
    }

    /*
    public void OnTriggerEnter(Collider pickedUpWeapon)
    {
       // Debug.Log("Player ran into:" + pickedUpWeapon.name);
        if (pickedUpWeapon.gameObject.name=="AK74") {
            Debug.Log("Player picked up:" + pickedUpWeapon.name);
            //pickedUpWeapon.gameObject.tag = "AK74";
            //playerHasWeapon.Add(pickedUpWeapon.name,true);
            Destroy(pickedUpWeapon.gameObject);
            amountOfWeapons++;

        }
        if (pickedUpWeapon.gameObject.name=="MachineGun")
        {
            Debug.Log("Player picked up:" + pickedUpWeapon.name);
            // pickedUpWeapon.gameObject.tag = "MachineGun";
            // playerHasWeapon.Add(pickedUpWeapon.name, true);
            amountOfWeapons++;
            Destroy(pickedUpWeapon.gameObject);
        }
    }
    */
}
