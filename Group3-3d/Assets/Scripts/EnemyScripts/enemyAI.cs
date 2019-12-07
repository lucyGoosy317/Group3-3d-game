using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public Rigidbody rigidbody;
    private NavMeshAgent agent;
    private EnemyAttack agentRange;
    private float rangeToStop;
    public bool isDead;
    private bool playerIsAlive;
    [Header("Enemy target")]
    public GameObject Player;
    
    [Header("Enemy Health")] 
    public int enemyHealth;

    [Header("Enemy Movement speed")]
    public float speed;
    public Animator enemyAnime;

    [Header("Enemy anime values")]
    public int movementValue;
    public int attackValue;
    public int dyingValue;


    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = speed;
       // agent.updatePosition = false;
        agent.SetDestination(Player.transform.position);
        agentRange = gameObject.GetComponent<EnemyAttack>();
        rangeToStop = agentRange.getRange();
        playerIsAlive = true;
        enemyAnime = gameObject.GetComponentInChildren<Animator>();
        isDead = false;
    }

    void Start()
    {

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       

        if (playerIsAlive==false)
           return;
        agent.SetDestination(Player.transform.position);
        if (enemyHealth>0) {
            enemyAnime.SetInteger("condition",movementValue);
           if (agent.remainingDistance < rangeToStop)
          {
                enemyAnime.SetInteger("condition", attackValue);
                //Debug.Log("Agent has reached Player"+agent.remainingDistance);
                agent.isStopped = true;
           } else
           if (agent.remainingDistance > rangeToStop)
           {
                enemyAnime.SetInteger("condition", movementValue);
                agent.isStopped = false;
          } else if (isDead)
            {
                enemyAnime.SetInteger("condition", 0);
                agent.isStopped = true;
           }
        }
        else
        {
            
           agent.isStopped = true;

           Death();
        }
        
    }

    public void subtractHealth(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth<=0)
        {

            Death();
        }
        Debug.Log("enemy health:"+enemyHealth);
    }

    public void knockback (float blast)
    {
        rigidbody.AddForce(Vector3.back * blast, ForceMode.Impulse);
    }


    public void Death()
    {
        enemyAnime.SetInteger("condition",3);
        Debug.Log("Enemy is dead");
        isDead = true;
        agent.isStopped = true;
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(waitToDestroy());
    }

    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public void playerIsDeadStopMoving(bool isDead)
    {
        playerIsAlive = isDead;
        agent.isStopped = true;
    }
   
    public bool emenyIsDead()
    {
        return isDead;
    }
   

}
