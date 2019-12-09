using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickRelic : MonoBehaviour
{

    public bool hasLevelRelic;
    // Start is called before the first frame update
    void Start()
    {
        hasLevelRelic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("relic5"))
        {
            hasLevelRelic = true;
            Debug.Log("Player has relic: "+ hasLevelRelic);
            Destroy(other.gameObject);
        }
    }

    public bool playerHasRelic()
    {
        return hasLevelRelic;
    }
}
