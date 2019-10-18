using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePlayerWeapons : MonoBehaviour
{
    public Text weaponDisplayLabel;
    public GameObject[] weapons;
    void Start()
    {
        weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        rotateThroughWeapons();
    }


    void rotateThroughWeapons()
    {
        int weaponCount = 0;
        if (Input.GetButtonDown("RightBump"))
        {
            weapons[weaponCount].SetActive(false);
            weaponCount++;
            weapons[weaponCount].SetActive(true);
        }  
    }

    
}
