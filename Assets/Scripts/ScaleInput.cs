using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleInput : MonoBehaviour
{
    public float scaleChange;
	private float scaleChangeX = 0f;
	private float scaleChangeY = 0f;
	private float scaleChangeZ = 0f;
	public bool changeX;
	public bool changeY;
	public bool changeZ;
	public float jumpForce;
	public Vector3 ChangeVector;
	
	void Update()
    {
		ChangeVectorXYZ();
		ScaleChange();
		ChangeXYZ();
		Scale();
		Jump();
	}
	void Scale()
	{
		Vector3 scale = transform.localScale;
		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (changeX == true)
			{
				scale.x += scaleChange;
			}
			if (changeY == true)
			{
				scale.y += scaleChange;
			}
			if (changeZ == true)
			{
				scale.z += scaleChange;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (changeX == true)
			{
				scale.x -= scaleChange;
			}
			if (changeY == true)
			{
				scale.y -= scaleChange;
			}
			if (changeZ == true)
			{
				scale.z -= scaleChange;
			}
		}
		transform.localScale = scale;
	}
	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
	void ChangeXYZ()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			changeX = !changeX;
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			changeY = !changeY;
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			changeZ = !changeZ;
		}
		
	}
	void ScaleChange()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			scaleChange -= scaleChange/2;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			scaleChange += scaleChange;
		}
	}
	void ChangeVectorXYZ()
	{
		if(changeX == true)
		{
			scaleChangeX = scaleChange;
		}
		else
		{
			scaleChangeX = 0;
		}
		if (changeY == true)
		{
			scaleChangeY = scaleChange;
		}
		else
		{
			scaleChangeY = 0;
		}
		if (changeZ == true)
		{
			scaleChangeZ = scaleChange;
		}
		else
		{
			scaleChangeZ = 0;
		}
		ChangeVector = new Vector3(scaleChangeX, scaleChangeY, scaleChangeZ);
	}
}
