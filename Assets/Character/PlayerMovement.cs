using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
public Animator animator;
public Joystick joystick;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
     if (joystick.Horizontal >= .2f) 
     {
        horizontalMove = runSpeed;
     } 
     else if (joystick.Horizontal <= -.2f)
     {
        horizontalMove = -runSpeed;
     }
     else
     {
        horizontalMove = 0f;
     }
     //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

    float verticalMove = joystick.Vertical;

     animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

     //if (Input.GetButtonDown("Jump"))
     if (verticalMove >= .2f)
     {
        jump = true;
     }

    //if (Input.GetButtonDown("Crouch"))
    if (verticalMove <= -.2f)
     {
        crouch = true;
     } else //if (Input.GetButtonUp("Crouch"))
     {
        crouch = false;
     }
    }

    void FixedUpdate ()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}
