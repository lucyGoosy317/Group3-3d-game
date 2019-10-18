using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;
    public int enemyHealth;



    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("PlayerPrefab");
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth >0) {
            agent.SetDestination(Player.transform.position);
            if (agent.remainingDistance < 3.5f)
            {
                agent = GetComponent<NavMeshAgent>();
                Debug.Log("Agent has reached Player");
                agent.isStopped = true;
            }
            if (agent.remainingDistance > 3.5f)
            {
                Debug.Log("Agent has not reached Player yet");
                agent.isStopped = false;
            }
        }
        else
        {
            agent.isStopped = true;
            Debug.Log("Enemy is dead");
        }
    }

    public void subtractHealth(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("enemy health:"+enemyHealth);
    }
}
