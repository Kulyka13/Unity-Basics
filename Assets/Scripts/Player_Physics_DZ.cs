using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Physics_DZ : MonoBehaviour
{
    public int Coins;
	private void OnCollisionEnter(Collision collision)
	{
        Coins++;
	}
}
