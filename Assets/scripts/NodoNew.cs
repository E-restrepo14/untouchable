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

        if (indice > -1 & indice < 1)
            indiceInt = 0 ;

        if (indice > 0 & indice < 2)
            indiceInt = 1;

        if (indice > 1 & indice < 3)
            indiceInt = 2;

        if (indice > 2 & indice < 4)
            indiceInt = 3;

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        audioSource.PlayOneShot(drift, Random.Range(0.5f, 0.1f));
    }

}
