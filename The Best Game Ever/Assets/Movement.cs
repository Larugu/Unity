using System;
using UnityEngine;

	
	public class Movement : MonoBehaviour {

	public float speed;
	public float runspeed = 12f;
	public float walkspeed = 4f;
	public float jumpSpeed;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;

	void Start() {

		jumpSpeed = 8.0f;
		gravity = 20.0f;
		GameObject Player = GameObject.Find("Player");
		Sved Sved = Player.GetComponent<Sved>();
	}
	


	void Update() {
		if (GameObject.Find("Player").GetComponent<Sved>().running) {
			speed = runspeed;
		} else {
			speed = walkspeed;
		}

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}