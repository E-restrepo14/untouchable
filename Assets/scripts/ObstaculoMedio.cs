﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMedio : AssetsMobiles
{
    new public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Sonar(privateAudio);

            Enemigo.GetComponent<EnemyScript>().StartCoroutine("AvanzarEnemigo");
            StartCoroutine("Realentizar");
        }

        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }
}