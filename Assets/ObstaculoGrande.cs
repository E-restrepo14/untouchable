using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoGrande : AssetsMobiles
{
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                Sonar(privateAudio);

                Enemigo.GetComponent<EnemyScript>().StartCoroutine("AdelantarEnemigo");
                StartCoroutine("Realentizar");
            }
        }
    }

    new public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }
}
