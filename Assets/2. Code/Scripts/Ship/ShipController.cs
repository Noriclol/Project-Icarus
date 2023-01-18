using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{


    private float forwardInput;
    private float turnInput;

    private float momentum = 0f;
    
    
    
    [SerializeField] 
    private float forwardForceMult = 10f;

    [SerializeField] 
    private float turningTorqueMult = 10f;
    
    
    private void ApplyForce()
    {
        var ForwardForce = transform.forward * forwardForceMult;
        
    }

    private void ApplyTurn()
    {
        //Debug.Log(turnInput);
    }
    
    
    private void FixedUpdate()
    {
        ApplyForce();
        ApplyTurn();
    }

    public void RegisterTurn(float input)
    {
        Debug.Log("InputRegistered");
        turnInput = input;
    }

    public void RegisterSpeed(float input)
    {
        forwardInput = input;
    }

}
