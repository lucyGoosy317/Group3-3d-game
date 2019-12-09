using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKeyPadInteract : MonoBehaviour
{
    private GameObject KeyPadInput;
    // Start is called before the first frame update
    void Start()
    {
        KeyPadInput = GameObject.FindGameObjectWithTag("keypadinput");
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("keypadinteract"))
        {
            gameObject.GetComponent<charController>().stopPlayerMovement = true;
            KeyPadInput.SetActive(true);
        }
    }

   


}
