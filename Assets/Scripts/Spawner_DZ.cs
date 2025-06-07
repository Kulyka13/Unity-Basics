using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_DZ : MonoBehaviour
{
	public GameObject chelikPrefab;
	public int numberOfObjects;
	public int destroyTime;
	public float minRange;
	public float maxRange;

	private void Start()
	{
		for (int i = 0; i < numberOfObjects; i++)
		{
		GameObject chelik = Instantiate(chelikPrefab, transform.position + new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5)), transform.rotation);
		chelik.transform.localScale = Vector3.one * Random.Range(minRange, maxRange);
		Destroy(chelik, destroyTime);
		}
	}
}
