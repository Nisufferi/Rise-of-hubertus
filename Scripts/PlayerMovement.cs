using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    float walkSpeed = 10;
    float sprintSpeed = 20;
    float jumpSpeed = 12;
    float gravity = 30f;
    [SerializeField]
    GameObject menu;

    Vector3 moveDirection;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        
    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown("escape"))
        {
            
            Application.LoadLevel("Menu");
            


        }
       

    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKey(KeyCode.LeftShift) && moveZ == 1)
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    
}
