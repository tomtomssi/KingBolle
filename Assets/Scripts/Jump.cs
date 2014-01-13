﻿using UnityEngine;



[RequireComponent(typeof(CharacterController))]



public class Jump : MonoBehaviour
	
{
	
	public float speed = 6.0f;
	
	public float jumpSpeed = 8.0f;
	
	public float gravity = 20.0f;
	
	
	
	private Vector2 moveDirection = Vector2.zero;
	
	private bool grounded = false;
	
	
	
	void FixedUpdate() 
		
	{
		
		if (grounded) 
			
		{
			
			// We are grounded, so recalculate movedirection directly from axes
			
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			
			moveDirection = transform.TransformDirection(moveDirection);
			
			moveDirection *= speed;
			
			
			
			if (Input.GetButton ("Jump"))  moveDirection.y = jumpSpeed;
			
		}
		
		
		
		// Apply gravity
		
		moveDirection.y -= gravity * Time.deltaTime;
		
		
		
		// Move the controller
		
		CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
		
		CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
		
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
		
	}
	
	
	
	
	
	
	
}