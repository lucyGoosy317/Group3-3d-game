using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ChangeEventSystem : MonoBehaviour
{
    private GameObject EventSys;
    private EventSystem eventController;

    public GameObject RestartButton;
    public GameObject NumberUI;
    
    // Start is called before the first frame update
    void Start()
    {
        //RestartButton = GameObject.FindGameObjectWithTag("restartDeath");
        EventSys = GameObject.FindGameObjectWithTag("eventSystem");
        //NumberUI = GameObject.FindGameObjectWithTag("numButton");
        eventController = EventSys.GetComponent<EventSystem>();
        //startButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startButton()
    {
        //eventController.firstSelectedGameObject(NumberUI);
    }


    public void changeEventSystem()
    {
        //RestartButton = GameObject.FindGameObjectWithTag("restartDeath");
        Debug.Log("Change button: "+RestartButton.name);
        eventController.SetSelectedGameObject( RestartButton);
    }
}
