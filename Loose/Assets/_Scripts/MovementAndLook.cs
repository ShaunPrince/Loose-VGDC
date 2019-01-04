﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovementAndLook : MonoBehaviour {

    public float lookSensitivity;
    public float moveSpeed;
    public float normalMoveSpeed;
    public float sprintingSpeed;
    
    public float gravity;


	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintingSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalMoveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(0, 500, 0);
        }
        look();




    }
    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= moveSpeed * Time.deltaTime * 14;

        this.GetComponent<Rigidbody>().AddForce(moveDir, ForceMode.VelocityChange);

        //this.gameObject.GetComponent<Rigidbody>().MovePosition(this.gameObject.transform.position + moveDir);
    }

    void look()
    {
        float scaledMouseDeltaX = Input.GetAxis("Mouse X") * lookSensitivity;
        float scaledMouseDeltaY = Input.GetAxis("Mouse Y") * lookSensitivity;

        this.gameObject.transform.Rotate(0, scaledMouseDeltaX, 0);
        float upDownLookAngle = this.gameObject.transform.GetComponentInChildren<Camera>().transform.eulerAngles.x;
        if (upDownLookAngle > 90)
        {
            upDownLookAngle -= 360;
        }

        if (upDownLookAngle - scaledMouseDeltaY < 80 && upDownLookAngle - scaledMouseDeltaY > -80)
        {

            this.gameObject.transform.GetComponentInChildren<Camera>().transform.Rotate(-scaledMouseDeltaY, 0, 0);
        }
    }
}
