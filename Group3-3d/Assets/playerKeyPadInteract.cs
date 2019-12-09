using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerKeyPadInteract : MonoBehaviour
{
    public GameObject KeyPadInput;
    private playerHealth playerhealthChecker;
    private GameObject EventSystem;
    private ChangeEventSystem eventSystemController;
    private bool alreadyChanged;
    // Start is called before the first frame update
    void Start()
    {
        alreadyChanged = false;
        playerhealthChecker = GetComponent<playerHealth>();
        //KeyPadInput = GameObject.FindGameObjectWithTag("keypadinput");
        //EventSystem = GameObject.FindGameObjectWithTag("eventSystem");
        eventSystemController = GetComponent<ChangeEventSystem>();
    }
    public void Update()
    {
        if (alreadyChanged)
            return;
        if (playerhealthChecker.healthAmount<=0)
        {

            Debug.Log("Starting change");
            eventSystemController.changeEventSystem();
            KeyPadInput.SetActive(false);
            alreadyChanged = true;
        }
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
