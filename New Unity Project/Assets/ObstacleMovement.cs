using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{   public Rigidbody rb;
    public float forwardForce;


    // Update is called once per frame
    void FixedUpdate()
    { 
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
    }
}
