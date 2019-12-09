using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRelic : MonoBehaviour
{
    public GameObject Relic3;
    public GameObject waypoint;
    public GameObject lvl4Checkpoint;
    public bool showing = false;

    private void Update()
    {
        if (showing)
        {
            Relic3.SetActive(true);
            lvl4Checkpoint.SetActive(true);
            waypoint.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            showing = true;
            //DisableEnemy(player.gameObject);
        }
        

    }
/*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            showing = true;
            DisableEnemy(collision.gameObject);
        }
    }

    void DisableEnemy(GameObject g)
    {

        var nv = g.GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (nv)
        {
            nv.enabled = false;
        }
        var ai = g.GetComponent<enemyAI>();
        if (ai)
        {
            ai.isDead = true;
        }

    }
    */
}