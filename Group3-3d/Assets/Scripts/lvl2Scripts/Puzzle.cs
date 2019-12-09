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

    private bool allTrue = false;
    void Start()
    {
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

    public void isCorrectPanel (string color)
    {
        if (color == nextColor)
        {
            int index = Array.IndexOf(order, color);
            if (index == (order.Length) - 1)
            {
                Debug.Log("You did it!");
                allTrue = true;
                return;
            }
            nextColor = order[index + 1];

            Debug.Log("Correct color. Next color is " + nextColor);
            return;

        }else
        {
            nextColor = order[0];
            Debug.Log("Wrong color");
            return;
        }
    }
}
