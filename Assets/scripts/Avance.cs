using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avance : MonoBehaviour 
{
	public Rigidbody riy;
	public float speed= -10.0f;

	void Start () 
	{
		riy.velocity = transform.forward*speed;
	}
}
