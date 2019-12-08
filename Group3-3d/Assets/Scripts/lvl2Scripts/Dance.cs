using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.black;
        Debug.Log(other.name);
    }
}
