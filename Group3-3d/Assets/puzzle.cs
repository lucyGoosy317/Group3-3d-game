using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{

    public static puzzle instance;

    public List<GameObject> pads;
    public GameObject door;

    public bool pad1 = false;
    public bool pad2 = false;
    public bool pad3 = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void padPressed(int id)
    {
        if(id == 1 && !pad2 && !pad3)
        {
            pad1 = true;
        }
        else if(id == 2 && pad3 && pad1)
        {
            pad2 = true;
        }
        else if((id == 3 && !pad2 && pad1))
        {
            pad3 = true;
        }
        else
        {
            pad1 = false;
            pad2 = false;
            pad3 = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pad1 && pad2 && pad3)
        {
            Destroy(door);
        }
    }
}
