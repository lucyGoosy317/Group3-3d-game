using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unlocklvl4Checkpoint : MonoBehaviour
{
    public GameObject goTolvl4;

    public bool showing = false;

    private void Update()
    {
        if (showing)
        {
            goTolvl4.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Enemy")
        {
            showing = true;
            DisableEnemy(player.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            showing = true;
            DisableEnemy(collision.gameObject);
        }
    }

    void DisableEnemy (GameObject g)
    {
        var nv = g.GetComponent<NavMeshAgent>();
        if (nv) {
            nv.enabled = false;
        }
        var ai = g.GetComponent<enemyAI>();
        if (ai)
        {
            ai.isDead = true;
        }

    }
}
