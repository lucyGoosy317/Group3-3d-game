using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour

{
    //private CharacterController characterController;
    //private Animator anime;

    float runSpeed = 25.0f;
    //public float walkBackspeed = 2.0f;
     float rotateSpeed = 15.0f;
    float gravity = 15;
    float jumpHeight = 10;
    private Vector3 moveDirection =Vector3.zero;
    public Animator playerAnime;
    void Start()
    {
        playerAnime = GetComponentInChildren<Animator>();

    }


    // Update is called once per frame


    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0,0,Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= runSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
                playerAnime.SetInteger("condition", 3);

            }
            if (Input.GetAxis("Vertical")>0)
            {
                playerAnime.SetInteger("condition",1);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                
                playerAnime.SetInteger("condition",2);
            }
            if(Input.GetAxis("Vertical") == 0)
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
            Debug.Log("Im getting hit");
        }


    }




}