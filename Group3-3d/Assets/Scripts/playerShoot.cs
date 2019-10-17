using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
   // public GameObject[] childObjects;
    public GameObject barrelLocation;
    public AudioSource gunNoises;
    public AudioClip gunShot;
    bool shootingGat;
    // Start is called before the first frame update
    void Start()
    {
        gunNoises = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shootingGat = true;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        findBarrelLocation();
        float fireTrigger = Input.GetAxis("Fire1");
        //Debug.Log(fireTrigger);
        if (fireTrigger>0 && shootingGat)
        {
            StartCoroutine(GunShootingAudio());
            Debug.Log("Fired");
            checkForHit();
        }
        
       
        //gunNoises.Stop();

    }
    //universal all gats will have a BarrelLocation
    void findBarrelLocation()
    {
        
        barrelLocation = GameObject.Find("BarrelLocation");
        
    }
    //testing, add if for enemy
    void checkForHit()
    {
        RaycastHit objectHit;
        Vector3 fwd = barrelLocation.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(barrelLocation.transform.TransformDirection(Vector3.forward),fwd,Color.red);
        if (Physics.Raycast(barrelLocation.transform.position, fwd, out objectHit, Mathf.Infinity))
        {
            Debug.Log("I hit :"+objectHit.collider.name);
        }
    }
  
    IEnumerator GunShootingAudio()
    {
        shootingGat = false;
        gunNoises.PlayOneShot(gunShot);
        yield return new WaitForSeconds(gunShot.length/4);
        shootingGat = true;
    }

}
