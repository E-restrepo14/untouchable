using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector3 EnemyPosition;

    private void Start()
    {
        EnemyPosition = transform.position;
    }

    public IEnumerator AvanzarEnemigo()
    {
        int contador = 0;

        while (contador < 4)
        {
            transform.Translate(0, 0, 0.25f);
            yield return new WaitForSeconds(0.0f);

            contador++;
        }
    }

    public IEnumerator AdelantarEnemigo()
    {
        int contador = 0;

        while (contador < 8)
        {
            transform.Translate(0, 0, 0.05f);
            yield return new WaitForSeconds(0.0f);

            contador++;
        }
    }

    public IEnumerator RetrocederEnemigo()
    {
        int contador = 0;

        while (contador < 4)
        {
            transform.Translate(0, 0, -0.125f);
            yield return new WaitForSeconds(0.0f);

            contador++;
        }
    }

}
