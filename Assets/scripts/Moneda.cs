using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : AssetsMobiles
{
    new public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sonar(privateAudio);
			GameManager.Instance.SubirTurbo ();
            GameManager.Instance.AlterarTotalMonedas(1);
			Enemigo.GetComponent<EnemyScript>().StartCoroutine("RetrocederEnemigo");

            //gameObject.SetActive(false);
        }

        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }

    }
}
