using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonMovment : MonoBehaviour
{   //Movement
    public CharacterController controller;
    public float speed = 6f;
    public float turnsmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float jumpHeight = 3f;
    
    //Gravity
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {   //ground check so gravity does not keep applying to player
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Horizontal and Vertial will use both wasd and the arrow keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        //movement in the x, y, z
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {   
            //making the player rotate to the direction they are traveling
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnsmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            //speed 
            controller.Move(direction * speed * Time.deltaTime);
        }
       
        //gravity
        if(Input.GetKeyDown("space") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
