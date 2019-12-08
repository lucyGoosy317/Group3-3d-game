using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour
{

    public GameObject lightobj;
    private Light lightController;
    bool lightLoop;
    // Start is called before the first frame update
    void Start()
    {
        lightLoop = true;
        lightController = gameObject.GetComponent<Light>();
        StartCoroutine(lightControl());
        //    InvokeRepeating("lightOn",0f,1f);
        //  InvokeRepeating("lightOff",0f,.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("light controller status" + lightController.range);
    }

    void lightOn()
    {
        
    }
    void lightOff()
    {
    }

    IEnumerator lightControl()
    {
        while (lightLoop!=false) {
            lightController.range = 10;
            yield return new WaitForSeconds(5f);
            
            lightController.range = 0;
        }
    }






}
