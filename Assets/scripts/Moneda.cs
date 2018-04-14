using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : AssetsMobiles
{
    //esta clase de obstaculos, tiene unas instrucciones que seguir cuando colisiona con el jugador
    // como atrasar la posicion del enemigo e ingresar a otros scripts y alterar valores que se almacenan en estos

    new public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sonar(privateAudio);
			GameManager.Instance.SubirTurbo ();
            GameManager.Instance.AlterarTotalMonedas(1);
			Enemigo.GetComponent<EnemyScript>().StartCoroutine("RetrocederEnemigo");
        }

        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }

    }
}
