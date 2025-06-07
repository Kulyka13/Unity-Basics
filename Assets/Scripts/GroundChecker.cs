using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	public bool isGrounded = true;
	private void OnTriggerEnter(Collider other)
	{
		isGrounded = true;
	}
	private void OnTriggerExit(Collider other)
	{
		isGrounded = false;
	}
}
