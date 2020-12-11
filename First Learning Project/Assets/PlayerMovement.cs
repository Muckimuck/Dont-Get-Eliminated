using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   public Rigidbody rb;
    public float forwardForce;
    public float sideForce;
    public float jumpForce;


    // Update is called once per frame
    void FixedUpdate()
    { 
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
        }
    }
}