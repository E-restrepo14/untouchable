using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    // en este script estan almacenados por array... los obstaculos, adornos y sus respectivas posiciones en los cuales se instanciarán al azar, por un random range.

    public static Instanciador Instance;
    public bool estaJugando = false;
    public float NextTime = 0.15f;
    [SerializeField]
    private float waitTime = 0;

    [SerializeField]
    private Transform[] puntosObstaculos;

    [SerializeField]
    private GameObject[] obstaculosPrefabs;

    [SerializeField]
    private Transform[] puntosAdornos;

    [SerializeField]
    private GameObject[] adornosPrefabs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    // este guarda una variable, que cada vez que vale verdadero, da la orden de instanciar por el update, este script ademas guarda otros dos subprocesos que pueden ser llamados por otros scripts
    private void Update()
    {
        if (estaJugando == true)
        {
            Instanciar();
        }
    }

    public void Parar()
    {
        estaJugando = false;
    }

    void Instanciar()
    {
        if ((GameManager.Instance.tiempoLimite - 15f) > 0)
        {
            while (Time.fixedTime > waitTime)
            {
                Instantiate(obstaculosPrefabs[Random.Range(0, (obstaculosPrefabs.Length))], puntosObstaculos[Random.Range(0, (puntosObstaculos.Length))].position, Quaternion.identity);
                waitTime = NextTime + Time.fixedTime;
                Adornar();
            }
        }
    }

    void Adornar()
    {
            Instantiate(adornosPrefabs[Random.Range(0, (adornosPrefabs.Length))], puntosAdornos[Random.Range(0, (puntosAdornos.Length))].position, Quaternion.Euler(0, Random.Range(0,360), 0));
    }
}
