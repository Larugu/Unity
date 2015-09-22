using System;
using UnityEngine;

	
	public class Movement : MonoBehaviour {

	public float speed;
	public float runspeed = 20f;
	public float walkspeed = 4f;
	public float jumpSpeed;
	public float angle = 0f;
	public float turnspeed = 1f;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	public Vector3 acspeed;

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
		acspeed = controller.velocity;
		//Debug.Log (acspeed);

		if (controller.isGrounded) {

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		angle += Input.GetAxis ("Mouse X");
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}