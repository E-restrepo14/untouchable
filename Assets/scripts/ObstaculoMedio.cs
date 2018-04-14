using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMedio : AssetsMobiles
{
    // este tipo de obstaculo tiene un efecto distinto a otros obstaculos cuando se encuentra con el tag player

    new public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Sonar(privateAudio);
            other.gameObject.GetComponent<PlayerMovement>().StartCoroutine("Caerse");
            Enemigo.GetComponent<EnemyScript>().StartCoroutine("AvanzarEnemigo");
        }
        // e igualmente se destruye al colisionar con el tag destructor
        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }
}