using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    public GameObject PuzzleMaster;
    private Puzzle puzzle;
    public string panelColor;
    public bool panelON;

    void Start ()
    {
        puzzle = PuzzleMaster.GetComponent<Puzzle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (puzzle.isCorrectPanel(panelColor))
            {
                panelON = true;
            }

        }

    }

     
}
