using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestroyOnTouchPhysicsDz : MonoBehaviour
{
    public GameObject platform;
    public Material material;
	public bool canShrink;
	public bool isShrinking;
	public float shrinkingSpeed;
	public int destroyTime;
	private void OnCollisionStay(Collision collision)
	{
		Vector3 currentScale = transform.localScale;
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material = material;
		if (currentScale.x > 0.0001f && currentScale.y > 0.0001f && currentScale.z > 0.0001f && canShrink == true)
		{
			currentScale.x -= shrinkingSpeed;
			currentScale.z -= shrinkingSpeed;
			transform.localScale = currentScale; 
			isShrinking = true;
		}
		else if(canShrink == false)
		{
			Destroy(gameObject, destroyTime);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		isShrinking = false;
	}
}
