using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject Relic2;
    public GameObject lvl3Checkpoint;
    public bool showing = false;

    public string[] order;
    private string nextColor;

    public static bool[] dancePanels = new bool[4];
    private bool allTrue = false;
    void Start()
    {
        dancePanels[0] = false;
        dancePanels[1] = false;
        dancePanels[2] = false;
        dancePanels[3] = false;

        order[0] = "Blue";
        order[1] = "Red";
        order[2] = "Yellow";
        order[3] = "Grey";  

        nextColor = order[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (allTrue)
        {
            Relic2.SetActive(true);
            lvl3Checkpoint.SetActive(true);
            
        }
    }

    public bool isCorrectPanel (string color)
    {
        if (color == nextColor)
        {
            int index = Array.IndexOf(order, color);
            nextColor = order[index];
            dancePanels[index] = true;
            Debug.Log("Correct color");
            return true;

        }else
        {
            nextColor = order[0];
            Debug.Log("Wrong color");
            return false;
        }
    }
}
