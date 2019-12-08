using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [Header("Player to Attack")]
    GameObject Player;
    [Header("Enemy attack stats")]
    public int attackDamage;
    public float attackRate;
    public float attackRange;
    private AudioSource attackSounds;
    //public AudioClip attackClip;

    //private fields
    private WaitForSeconds attackDuration;
    private float nextAttack;
    private playerHealth damagePlayer;
    enemyAI stopMoving;
    GameObject spawner;
    EnemySpawner stopSpawner;
    private bool spawnStopping;
    string spawnName = "spawner";


    private void Awake()
    {
       // spawner = GameObject.FindGameObjectWithTag(spawnName);
       // stopSpawner = spawner.GetComponent<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnStopping = false;
        attackSounds = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
        damagePlayer = Player.GetComponent<playerHealth>();
        stopMoving = gameObject.GetComponent<enemyAI>();
        
      //  attackDuration = new WaitForSeconds(attackClip.length);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopMoving.emenyIsDead())
            return;

        Vector3 heading = Player.transform.position - gameObject.transform.position;
        float distance = heading.magnitude;
        if (heading.sqrMagnitude< attackRange * attackRange && Time.time>nextAttack)
        {
            nextAttack = Time.time + attackRate;
            //start coroutine
            RaycastHit hit;

            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(gameObject.transform.TransformDirection(Vector3.forward), fwd, Color.red);
            //Debug.Log("Enemy is close enough to attack"+distance);
            if (Physics.Raycast(gameObject.transform.position,fwd,out hit, attackRange))
            {
                        
                damagePlayer = hit.collider.GetComponent<playerHealth>();
                if (damagePlayer !=null)
                {
                    // Debug.Log("Enemy is hiting player");
                    //dont attack if player health is 0
                    int playerHealth = damagePlayer.getPlayerHealth();
                    if (playerHealth <= 0)
                    {
                        //spawnStopping = true;
                        stopMoving.playerIsDeadStopMoving(false);
                        //stopSpawner.stopSpawning(spawnStopping);
                        return;
                    }
                    damagePlayer.takeDamage(attackDamage);
                }

            }
        }
        else
        {
           // Debug.Log("Enemy is still to far"+distance);
        }
    }

    public float getRange()
    {
        return attackRange;
    }

    IEnumerator attack()
    {
        Debug.Log("Playing enemy attack sound");
        yield return attackDuration;
        Debug.Log("End Playing enemy attack sound");
    }

    
}
