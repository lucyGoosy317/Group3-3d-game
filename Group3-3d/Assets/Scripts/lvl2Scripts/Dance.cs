using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{

    private Puzzle puzzle;
    public string panelColor;
    public bool panelON;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (puzzle.isCorrectPanel(panelColor))
            {
                
                Debug.Log("Panel on");
            }

        }

    }

     
}
