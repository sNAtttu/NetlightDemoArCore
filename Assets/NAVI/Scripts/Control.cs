using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour 
{
	public float rotationDamping = 20f;
	public float speed = 10f;
	public int gravity = 0;
	public Animator animator;
	
	float verticalVel;  // Used for continuing momentum while in air    
	CharacterController controller;
	
	void Start()
	{
		controller = (CharacterController)GetComponent(typeof(CharacterController));
	}

	float UpdateMovement()
	{
		// Movement
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= speed;
		
		controller.Move((inputVec + Vector3.up * -gravity + new Vector3(0, verticalVel, 0)) * Time.deltaTime);
		
		// Rotation
		if (inputVec != Vector3.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, 
			                                      Quaternion.LookRotation(inputVec), 
			                                      Time.deltaTime * rotationDamping);
		
		return inputVec.magnitude;
	}

	void AnimationControl ()
	{
		if(Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("w")) 
		{
			animator.SetBool ("Moving" , true);
		}
		else
		{
			animator.SetBool ("Moving" , false);
		}
		
		if(Input.GetKey("space")) 
		{
			animator.SetBool ("Angry" , true);
		}
		else
		{
			animator.SetBool ("Angry" , false);
		}

		if(Input.GetKey("mouse 0")) 
		{
			animator.SetBool ("Scared" , true);
		}
		else
		{
			animator.SetBool ("Scared" , false);
		}
	
	}

	void Update()
	{	
		UpdateMovement();
		AnimationControl();


		if ( controller.isGrounded )
			verticalVel = 0f;// Remove any persistent velocity after landing
	}
}
