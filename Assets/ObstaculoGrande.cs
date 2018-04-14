using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoGrande : AssetsMobiles
{
    // este script lo tiene un obstaculo especial, que se encarga de afectar al jugador, si este se mueve mientras está dentro de su collider


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                Sonar(privateAudio);
                other.gameObject.GetComponent<PlayerMovement>().StartCoroutine("Caerse");
                Enemigo.GetComponent<EnemyScript>().StartCoroutine("AdelantarEnemigo");
            }
        }
    }
    // y al chocar con el objeto con tag destructor se destruirá para no cargar la escena
    new public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }
}
