using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciador : MonoBehaviour {

	public GameObject []obstacles ;
	int resultado;
	int spawnposition;
	public GameObject indicador; 
	public Transform []emptys ;
	public float spawnWait;
	public float waveWait;
	public float startWait;
	public int hazardCount;
	public float DuracionJuego;
	private float Tiempodejuego;


	void Update () 
	{	
		
		resultado = Random.Range (0, 6) + Random.Range (0, 6);
		
		if ((resultado == 7) ||(resultado == 8)||(resultado == 10)||(resultado == 12)) 
		{
			indicador = obstacles[Random.Range (0, 2)];		
		}

		if ((resultado == 3) ||(resultado == 6)||(resultado == 9)||(resultado == 11)) 
		{
			indicador = obstacles[2];		
		}

		if ((resultado == 4) ||(resultado == 5)) 
		{
			indicador = obstacles[Random.Range (3, 5)];		
		}

		if ((resultado == 2)) 
		{
			indicador = obstacles[Random.Range (5, 7)];		
		}
	}

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	//-------------------------------------------------------
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 target = emptys [Random.Range (0, 4)].position;

				Instantiate (indicador, target, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
