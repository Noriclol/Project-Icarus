using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //components
    [SerializeField]
    private Rigidbody rb;
    
    [SerializeField]
    private Transform orientation;

    [SerializeField] 
    private Transform playerObj;
    
    //refs
    private GameObject PlayerObject;
    public GameObject vCam;
    public Transform camPos;
        
    //Fields
    private Vector2 _input;
    private Vector3 moveDirection;
    
    [SerializeField] 
    private float TopSpeed = 0.5f;
    
    [SerializeField] 
    private float topSpeedTime = 2f;
    
    [SerializeField] 
    private AnimationCurve accelerationCurve;
    
    private float timer = 0;
    
    [SerializeField] 
    private float rotationSpeed = 16f;

    [SerializeField] 
    private float JumpForce = 2f;
    
    private void Update()
    {
        SetDirectionFree();
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        SetMoveSpeed(1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, moveDirection);
    }


    private void SetDirectionFree()
    {
        Vector3 viewDir = transform.position - new Vector3(camPos.position.x, transform.position.y, camPos.position.z);
        orientation.forward = viewDir.normalized;
        
        moveDirection = orientation.forward * _input.y + orientation.right * _input.x;

        if (moveDirection != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, moveDirection.normalized, Time.deltaTime * rotationSpeed);
    }
    
    
    private void SetMoveSpeed(int i)
    {

        //Vector3 newMovement = moveDirection.normalized * (TopSpeed * accelerationCurve.Evaluate(timer / topSpeedTime)) * (float)i;
        Vector3 newMovement = moveDirection.normalized * TopSpeed;
        newMovement.y = rb.velocity.y;
        
        rb.velocity = newMovement;
    }
    

    public void OnMoveInput(Vector2 input)
    {
        
        if (input == Vector2.zero)
        {
            timer = 0;
            //print("timerReset");
        }
        
        _input = input;
        //print($"input: {input}");
    }

    public void OnJump()
    {
        rb.AddForce(playerObj.up * JumpForce * 150);
        print($"Jumping");
    }
    public void OnInteract()
    {
        //print($"Interacting");
    }
}
