using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour

{
    private CharacterController controller;
    private float runSpeed = 25.0f;
    private float rotateSpeed = 5.0f;
    private float gravity = 15;
    private float jumpHeight = 10;
    private Vector3 moveDirection =Vector3.zero;
    private Animator playerAnime;
    private bool isAlive;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerAnime = GetComponentInChildren<Animator>();
        isAlive = true;

    }


    // Update is called once per frame


    void Update()
    {
        
        //CharacterController controller = GetComponent<CharacterController>();
        Debug.Log("player is:" +isAlive);
        if (isAlive==false)
            return;


            if (controller.isGrounded)
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= runSpeed;
                //if (Input.GetButton("Jump"))
                //{
                  //  moveDirection.y = jumpHeight;
                  //  playerAnime.SetInteger("condition", 3);

                //}
                if (Input.GetAxis("Vertical") > 0)
                {
                    playerAnime.SetInteger("condition", 1);
                }
                if (Input.GetAxis("Vertical") < 0)
                {

                    playerAnime.SetInteger("condition", 2);
                }
                if (Input.GetAxis("Vertical") == 0)
                {
                    playerAnime.SetInteger("condition", 0);
                }

            }

            moveDirection.y -= gravity * Time.deltaTime;
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            controller.Move(moveDirection * Time.deltaTime);

        
        
       
        

    }


    //Getting attacked by the enemy
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="EnemyMelee")
        {
           // Debug.Log("Im getting hit");
        }


    }

    public void isDead(bool playerDead)
    {
       // Debug.Log("player was killed"+);
        isAlive = playerDead;
       
        
    }


}