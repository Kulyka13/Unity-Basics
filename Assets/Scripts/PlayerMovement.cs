using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	public float jumpForce;

	public bool isGrounded;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Move();
		Jump();
	}

	void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
	void Move()
	{
		float horizontal = Input.GetAxis("Horizontal"); // -1... 0 . 0.3 .. 1
		float vertical = Input.GetAxis("Vertical"); // -1... 0 . 0.3 .. 1

		Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

		if (moveDirection.magnitude > 1)
		{
			moveDirection = moveDirection.normalized;
		}

		moveDirection *= moveSpeed;

		moveDirection.y = rb.velocity.y;

		rb.velocity = moveDirection;
	}

	private void OnTriggerStay(Collider other)
	{
		isGrounded = true;
	}
	private void OnTriggerExit(Collider other)
	{
		isGrounded = false;
	}
}
