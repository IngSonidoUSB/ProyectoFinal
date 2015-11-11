﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public GameControlScript control;
	private Vector3 moveDirection = Vector3.zero;
	
	//start 
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update (){
		if (controller.isGrounded) {
			GetComponent<Animation>().Play("Andando");            //play "run" animation if spacebar is not pressed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 
			
			if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
				GetComponent<Animation>().Stop("Andando");
				GetComponent<Animation>().Play("Truco3");
				moveDirection.y = jumpSpeed;         //add the jump height to the character
				control.totalJumps++;
			}
			if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				isGrounded = true;
		}
		
		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}
	

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Tomando: "+ other.gameObject.name);
		if(other.gameObject.name == "MonedaDorada")
		{
			control.PowerupCollected();
			//Debug.Log("Tomando Moneda Dorada");
			control.totalCoins++;
		}
		else if(other.gameObject.name != "MonedaDorada")
		{
			control.AlcoholCollected();
			//Debug.Log("Tomando Moneda Plateada");
			control.totalCoins++;
		} 
		Destroy(other.gameObject.transform.parent.gameObject);            
		
	}
}