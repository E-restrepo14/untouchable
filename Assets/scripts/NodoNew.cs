using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoNew : MonoBehaviour
{
    [SerializeField]
    private AudioClip drift;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    float indice;
    public int indiceInt;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        indice = (transform.position.x) + 1;
    }

    // este script se encuentra dentro de un empty con collider en la posicion de cada uno de los cuatro carriles de la pista, y cada que detectan que el jugador entra en ellos, 
    //se da la orden a un audiosource que reproduzca el sonido de un derrape
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        audioSource.PlayOneShot(drift, Random.Range(0.5f, 0.1f));
    }

}
