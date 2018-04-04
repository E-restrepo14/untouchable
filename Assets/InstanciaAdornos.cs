using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaAdornos : MonoBehaviour {

	public GameObject []adornos ;
	int resultado;
	int spawnposition;
	public GameObject indicador; 
	public Transform []emptys ;
	public float spawnWait;
	public float waveWait;
	public float startWait;
	public int hazardCount;

	void Update () 
	{
		resultado = Random.Range (0, 12);

		if (resultado == 1) 
		{
			indicador = adornos[0];		
		}

		if (resultado == 2)  
		{
			indicador = adornos[1];		
		}

		if (resultado == 3) 
		{
			indicador = adornos[2];		
		}

		if (resultado == 4) 
		{
			indicador = adornos[3];		
		}

		if (resultado == 5) 
		{
			indicador = adornos[4];		
		}

		if (resultado == 6) 
		{
			indicador = adornos[5];		
		}
		if (resultado == 7) 
		{
			indicador = adornos[6];		
		}
		if (resultado == 8) 
		{
			indicador = adornos[7];		
		}
		if (resultado == 9) 
		{
			indicador = adornos[8];		
		}
		if (resultado == 10) 
		{
			indicador = adornos[9];		
		}
		if (resultado == 11) 
		{
			indicador = adornos[10];		
		}
		if (resultado == 12) 
		{
			indicador = adornos[11];		
		}
	}

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 target = emptys [Random.Range (0, 6)].position;

				Instantiate (indicador, target, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
