using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRigidBody : MonoBehaviour
{
    

    
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationSpeed = 360.0f;

    public float moveSpeed = 10;

    private Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;
    
    //private Rigidbody characterRigidBody;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
         rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        ApplyInput(moveAxis,turnAxis);
        // if (controller.isGrounded )
        //{

        // moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        // moveDirection = transform.TransformDirection(moveDirection);
        // moveDirection *= speed;
        //   float rotate = Input.GetAxis("Horizontal")* rotationSpeed;
        // rotate *= Time.deltaTime;
        //transform.Rotate(0,rotate,0);

        //  if (Input.GetButton("Jump"))
        //  {
        //     moveDirection.y = jumpSpeed;
        // }
        // }


        // moveDirection.y -= gravity * Time.deltaTime;



        // controller.Move(moveDirection*Time.deltaTime);

    }
    private void ApplyInput(float moveInput, float turnInput)
    {
        move(moveInput);
        turn(turnInput);
    }

    private void move(float input)
    {
        //transform.Translate(Vector3.forward * input * speed *Time.deltaTime);
        rb.AddForce(transform.forward * input * moveSpeed , ForceMode.Force);
    }

    private void turn(float input)
    {
        transform.Rotate(0,input* rotationSpeed * Time.deltaTime,0);
    }
}
