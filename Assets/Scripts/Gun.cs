using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public float shootPower = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        Shoot();
        }
    }

    public void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefab,
                    shootPoint.position,
                    shootPoint.rotation);



        spawnedBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootPower, ForceMode.Impulse);

		Destroy(spawnedBullet, 10);
	}
}
