using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{


    [SerializeField]
    private float forwardInput = 1;
    [SerializeField]
    private float turnInput = 0;

    private float momentum = 0f;

    private Rigidbody rb;
    private BoxCollider collider;
    
    [SerializeField]
    public GameObject vCam;
    
    [SerializeField] 
    private float forwardForceMult = 10f;

    [SerializeField] 
    private float turningTorqueMult = 10f;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }


    private void ApplyForce()
    {
        if (forwardInput == 0)
            return;
        
        var ForwardForce = transform.forward * forwardForceMult * forwardInput;
        rb.AddForce(ForwardForce);
    }

    private void ApplyTurn()
    {
        if (turnInput == 0)
            return;
        
        rb.AddTorque(new Vector3(0, turnInput * turningTorqueMult, 0));
        //Debug.Log(turnInput);
    }
    
    
    private void FixedUpdate()
    {
        // ApplyForce();
        // ApplyTurn();
    }

    public void RegisterTurn(float input)
    {
        Debug.Log($"Turn {input}");
        Debug.Log("Turning");
        turnInput = input;
    }

    public void RegisterSpeed(float input)
    {
        Debug.Log($"Turn {input}");
        Debug.Log("Speeding");

        forwardInput = input;
    }

}
