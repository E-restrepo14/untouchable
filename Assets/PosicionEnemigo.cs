using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionEnemigo : MonoBehaviour {


	public Transform[] posiciones;
	public float rapidezenemigo=4.0f;

	Transform posicionencia;
	int seleccionar=0;



	void Update ()
	{
		posicionencia = posiciones [seleccionar];
		transform.position = Vector3.MoveTowards (transform.position, posicionencia.position, rapidezenemigo * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("TagChoco"))
		{
			enemigoavanza ();
		}

		if (other.gameObject.CompareTag ("TagPico")) 
		{
			enemigoretrocede ();
		}
	}

	//----------------------------------------------------------
	void enemigoretrocede ()
	{
		if (seleccionar > 0) 
		{
			seleccionar = (seleccionar - 1);
		}
	}

	void enemigoavanza() 
	{
		if (seleccionar < 6) 
		{
			seleccionar = (seleccionar + 1);
		}
	}

}
