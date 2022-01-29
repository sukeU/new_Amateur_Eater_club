using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    public float Movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(1.0f, 0.0f, 0.0f);
        rb.AddForce(mouseDelta * Movespeed);


        
    }

    
}
