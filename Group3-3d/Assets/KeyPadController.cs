using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadController : MonoBehaviour
{
    //player stops moving when using
    private GameObject player;
    public charController playerMovementController;

    private GameObject KeyCodeInputUI;

    private GameObject GateKeeper;

    private GameObject keypadInteract;
    private KeyPadController disableKeypad;
    private string inputString;
    private string correctCode;
    // Start is called before the first frame update
    void Start()
    {
        inputString = "";
        correctCode = "DEADBEEF";
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementController = player.GetComponent<charController>();
        GateKeeper = GameObject.FindGameObjectWithTag("gatekeeper");
        KeyCodeInputUI = GameObject.FindGameObjectWithTag("keypadinput");
        KeyCodeInputUI.SetActive(false);
        keypadInteract = GameObject.FindGameObjectWithTag("keypadinteract");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonA()
    {
        //play sound
        inputString += "A";
        Debug.Log("current InputString: "+inputString);
    }
    public void ButtonB()
    {

        inputString += "B";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonC()
    {

        inputString += "C";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonD()
    {

        inputString += "D";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonE()
    {

        inputString += "E";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonF()
    {

        inputString += "F";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonG()
    {

        inputString += "G";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonH()
    {

        inputString += "H";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonI()
    {

        inputString += "I";
        Debug.Log("current InputString: " + inputString);
    }
    public void ButtonEnter()
    {
        if (inputString.Contains(correctCode))
        {
            //play sound
            Debug.Log("Correct!");
            playerMovementController.stopPlayerMovement = false;
            KeyCodeInputUI.SetActive(false);
            keypadInteract.GetComponent<Collider>().enabled = false;
            Destroy(GateKeeper);

        }
        else
        {
            //play sound
            Debug.Log("Wrong!");
            inputString = "";
            playerMovementController.stopPlayerMovement = false;
            KeyCodeInputUI.SetActive(false);
        }
    }
    public void ButtonClear()
    {
        //play sound
        inputString = "";
        Debug.Log("Input string is now clear: "+inputString);
    }
    public void ButtonExit()
    {
        //play sound
        KeyCodeInputUI.SetActive(false);
        playerMovementController.stopPlayerMovement = false;
    }
}
