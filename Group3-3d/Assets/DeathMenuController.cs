using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeathMenuController : MonoBehaviour
{
    private string titleMenuString = "Title";
    
    // Start is called before the first frame update
    void Awake()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void restartlevel()
    {
        Debug.Log("Restarting level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void startMenu()
    {
        Debug.Log("going to start menu");
        SceneManager.LoadScene(titleMenuString);
        
    }
}
