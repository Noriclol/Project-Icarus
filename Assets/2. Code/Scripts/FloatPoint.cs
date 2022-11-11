using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField] 
    private float LiftForce = 10f;
    
    [SerializeField]  
    private List<Transform> FloatingPoints;

    private float LevitateAt;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (var transform in FloatingPoints)
        {
            var delta = transform.position.y - LevitateAt;
            if (delta >= 0)
            {
                print("Above water");
            }
            else
            {
                var buoyancy = Mathf.Abs(delta);
                
                //44444rb.AddForce();
                print("Below water");
            }
        }
    }
}
