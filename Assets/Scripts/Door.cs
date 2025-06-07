using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			animator.SetBool("open", true);
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			animator.SetBool("open", false);
		}
	}


}
