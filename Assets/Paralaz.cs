using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaz : MonoBehaviour
{
    [SerializeField]
    private float velocidadCiudad;

    [SerializeField]
    private Vector3 newPosicion;



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
