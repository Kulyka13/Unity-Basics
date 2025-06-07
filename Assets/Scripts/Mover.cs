using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public Vector3 moveVector;
	public Vector3 rotationVector;
	public Vector3 scaleVector;
	public float moveSpeed;
	private void Start()
	{
	}
	void Update()
    {
		transform.Rotate(rotationVector);
		transform.localScale = scaleVector;	
		Move();
	}

	void Move()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		float movementY = 0;
		if(Input.GetKey(KeyCode.LeftShift))
		{
			movementY = -1;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			movementY = 1;
		}
		moveVector = new Vector3(horizontal, movementY, vertical);



		transform.position += moveVector * moveSpeed / 1000;
	}
}
