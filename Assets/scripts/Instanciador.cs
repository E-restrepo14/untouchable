using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    public static Instanciador Instance;
    public bool estaJugando = false;

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

    private void Update()
    {
        Instanciar();
    }

    [SerializeField]
    private float NextTime = 0.15f;
    [SerializeField]
    int counter = 5;
    [SerializeField]
    private float waitTime = 0;

    void Instanciar()
    {

        if (estaJugando == true)
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

    public void Parar()
    {
        estaJugando = false;
    }
}
