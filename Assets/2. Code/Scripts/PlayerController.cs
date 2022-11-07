using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //components
    private Rigidbody rb;
    
    //refs
    private GameObject PlayerObject;
    private GameObject vCam;
    
        
    //Fields
    private Vector2 _input;
    
    public void OnMoveInput(Vector2 input)
    {
        _input = input;
        print($"input: {input}");
    }

    public void OnJump()
    {
        print($"Jumping");
    }
    public void OnInteract()
    {
        print($"Interacting");
    }
}
