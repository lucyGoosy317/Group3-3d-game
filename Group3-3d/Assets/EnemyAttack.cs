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
    [Header("Attack sound")]
    private AudioSource attackSounds;
    public AudioClip attackClip;

    //private fields
    private WaitForSeconds attackDuration;
    private float nextAttack;
    private playerHealth damagePlayer;
    enemyAI stopMoving;
    GameObject spawner;
    EnemySpawner stopSpawner;
    private bool spawnStopping;
    string spawnName = "spawner";
    private playerHealth playerHealthChecker;

    private void Awake()
    {
        //spawner = GameObject.FindGameObjectWithTag(spawnName);
       // stopSpawner = spawner.GetComponent<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnStopping = false;
        attackSounds = GetComponent<AudioSource>();
        attackDuration = new WaitForSeconds(5f);
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealthChecker = Player.GetComponent<playerHealth>();
        damagePlayer = Player.GetComponent<playerHealth>();
        stopMoving = gameObject.GetComponent<enemyAI>();
        
      //  attackDuration = new WaitForSeconds(attackClip.length);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthChecker.healthAmount<=0)
        {
            attackSounds.Stop();
            stopMoving.playerIsDeadStopMoving(false);
            return;
        }

        if (stopMoving.emenyIsDead())
            return;

        Vector3 heading = Player.transform.position - gameObject.transform.position;
        float distance = heading.magnitude;
        if (heading.sqrMagnitude< attackRange * attackRange && Time.time>nextAttack)
        {
            nextAttack = Time.time + attackRate;
            //start coroutine
             StartCoroutine(attack());
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
                        spawnStopping = true;
                        stopMoving.playerIsDeadStopMoving(false);
                        
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
        attackSounds.clip = attackClip;
        attackSounds.Play();
        yield return new WaitForSeconds(attackClip.length);
        attackSounds.Stop();
        Debug.Log("End Playing enemy attack sound");
    }

    
}
