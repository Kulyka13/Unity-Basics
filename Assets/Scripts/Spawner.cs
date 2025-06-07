using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject chelikPrefab;

	void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
        //GameObject chelik = Instantiate(chelikPrefab, transform.position + new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5)), transform.rotation);
		GameObject chelik = Instantiate(chelikPrefab, transform.position, transform.rotation);
		//chelik.transform.localScale = Vector3.one * Random.Range(0.5f, 2);

        //chelik.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(Random.value, 1, 1); // new Color(Random.value, Random.value, Random.value);
        Destroy(chelik, 10);
        }
    }
}
