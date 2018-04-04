using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 

{

    [SerializeField]
    GameObject piernas;
    [SerializeField]
    GameObject piernasparadas;
    [SerializeField]
    Transform FuncionalSpawner;
    [SerializeField]
    float fireRate;

	private float nextFire;

    [SerializeField]
    GameObject AlertaPerdioUnTurno;
    [SerializeField]
    GameObject SeñalPico;

    [SerializeField]
    Transform[] carriles;
    [SerializeField]
    GameObject[] cubitos;
    [SerializeField]
    float rapidez;
    [SerializeField]
    int count;
    [SerializeField]
    int porcentajedenitro;
    [SerializeField]
    Text cointext;
    [SerializeField]
    static bool turnosperdidos= false;
    [SerializeField]
    static bool pico = false;


	Transform carril;
	int seleccionar=2;

	void Start()
	{
		count = 0;
		porcentajedenitro = 0;
		SetCountText ();

	}

	void Update() 
	{


		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			if (seleccionar > 0) 
			{
				seleccionar = (seleccionar - 1);
			}
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			if (seleccionar < 3) 
			{
				seleccionar = (seleccionar + 1);
			}
		}

		carril = carriles [seleccionar];
			transform.position = Vector3.MoveTowards (transform.position, carril.position, rapidez * Time.deltaTime);
	



	}


	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Collectables")) 
			{
			Destroy(other.gameObject);
			count = count + 1;
			porcentajedenitro = porcentajedenitro + 1;
			SetCountText ();
			//Debug.Log ("Se estan recolectando monedas");


			if (porcentajedenitro >= 5) 
			{
				cubitos [0].SetActive (true);
			}
			if (porcentajedenitro >= 10) 
			{
				cubitos [1].SetActive (true);
			}
			if (porcentajedenitro >= 15) 
			{
				cubitos [2].SetActive (true);
			}
			if (porcentajedenitro >= 20) 
			{
				cubitos [3].SetActive (true);
			}
			if (porcentajedenitro >= 25) 
			{
				cubitos [4].SetActive (true);
			}
			if (porcentajedenitro >= 30) 
			{
				cubitos [5].SetActive (true);
			}
			if (porcentajedenitro >= 34) 
			{
				cubitos [6].SetActive (true);
			}

			if (porcentajedenitro >= 35) 
			{
				//MetioElNitro.enabled = true;
				metioElNitro();
				porcentajedenitro = 0;
				cubitos [0].SetActive (false);
				cubitos [1].SetActive (false);
				cubitos [2].SetActive (false);
				cubitos [3].SetActive (false);
				cubitos [4].SetActive (false);
				cubitos [5].SetActive (false);
				cubitos [6].SetActive (false);
			}
			}

		//-----------------

		if (other.gameObject.CompareTag ("Obstaculos"))
			{
				//Instantiate (sangre, other.transform.position, other.transform.rotation);
			acaboElNitro ();	
			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				Instantiate (AlertaPerdioUnTurno, FuncionalSpawner.position, FuncionalSpawner.rotation);
			}

			}
	
		if (other.gameObject.CompareTag ("Antiobstaculos"))
			{
			if ((Input.GetKeyDown (KeyCode.LeftArrow)) || (Input.GetKeyDown (KeyCode.RightArrow))) 
				{
					
				acaboElNitro ();
					Instantiate (AlertaPerdioUnTurno, FuncionalSpawner.position, FuncionalSpawner.rotation);

				}
			}

	}
	//----------------------------------------------------

	void SetCountText ()
	{
		cointext.text = "Monedas: " + count.ToString ();
	}

	//----------------------------------------------------

	void acaboElNitro ()
	{

		piernas.SetActive(true);
		piernasparadas.SetActive(false);
	}


	void metioElNitro ()
	{
		
		piernas.SetActive(false);
		piernasparadas.SetActive(true);

		Instantiate (SeñalPico, FuncionalSpawner.position, FuncionalSpawner.rotation);

	}
}

