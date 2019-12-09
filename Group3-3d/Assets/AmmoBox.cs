using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{

    [Header("AmmoBox Type")]
    public string AmmoBoxTag;
    public int minFill;
    public int maxFill;
    private int randomAmountFill;


    // Start is called before the first frame update
    void Awake()
    {
        gameObject.tag = AmmoBoxTag;
        randomAmountFill = Random.Range(minFill,maxFill);
    }
   // void Update()
    //{
      //  randomAmountFill = Random.Range(minFill, maxFill);
    //}

    public int ammoutToFill()
    {
        Debug.Log("Amount to fill:"+randomAmountFill);
        return randomAmountFill;
    }

    
}
