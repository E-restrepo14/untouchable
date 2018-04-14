using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaz : MonoBehaviour
{
    [SerializeField]
    private float velocidadCiudad;

    [SerializeField]
    private Vector3 newPosicion;

    // este script lo tendran una clase especial de assets que adornan la escena y esto hace que los assets avancen y reaparezcan en una posicion cuando llegan mas allá de un limite.

    void Update()
    {
        transform.Translate(-Vector3.forward * velocidadCiudad * Time.deltaTime);

        if (transform.position.z < -8.253f)
        {
            newPosicion = transform.position;
            newPosicion.z = 500f;
            transform.position = newPosicion;

        }
    }
}
