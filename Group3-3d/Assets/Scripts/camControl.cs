using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 camOffset;

    [Range(0.01f,1.0f)]
    public float Smoothness = 0.5f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;
    public float RotationSpeed=5.0f;
    
    // Update is called once per frame
    void Start()
    {
        camOffset = transform.position - PlayerTransform.position;    
    }

    private void LateUpdate()
    {
        
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            camOffset = camTurnAngle * camOffset;

            Vector3 newPos = PlayerTransform.position + camOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, Smoothness);

            if (LookAtPlayer || RotateAroundPlayer)
            {
                transform.LookAt(PlayerTransform);
            }
        }

    }
    }

