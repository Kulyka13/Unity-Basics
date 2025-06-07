using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisions : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Rigidbody>().sleepThreshold = 0;
	}
	public float health = 100;
	public int points;
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.name);
		
		if(collision.gameObject.tag == "Money")
		{
			points++;
			Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "Heal")
		{
			health += 25;
			Destroy(collision.gameObject);
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		Debug.Log(collision.gameObject.name);
	}
	private void OnCollisionStay(Collision collision)
	{
	}
	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Lava")
		{
			health -= 0.1f;
		}
		
	}
}
