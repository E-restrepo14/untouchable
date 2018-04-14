using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Camera m_MainCamera;
    Vector3 posicionDeLaCamara;
    
	int i = 1;
	int j = -1;
	int contador = 0;

    private void Awake()
    {
        m_MainCamera = Camera.main;
        posicionDeLaCamara = m_MainCamera.transform.position;
    }
    //==============================================================================================================

    #region Movimiento 
    [SerializeField]
    Transform [] carriles;

    
    void Update ()
    {
       
        // lo que está dentro de este if, es solo para decorar la animacion del pedaleo del ciclista, ya que esta se ve muy rigida y antinatural
		if (UiManager.Instance.estaPausado == false)
		{
			transform.rotation = Quaternion.Euler(0, 0, i*2);
			i = i + j;
			if (i <= -5 || i >= 5)
			{
				contador++;
				j *= -1;
			}
		}

        // la camara se desplazará en x. la mitad de lo que se desplace el personaje principal y lo hará con una transicion de un lerp.
        posicionDeLaCamara = new Vector3 (Mathf.Lerp (posicionDeLaCamara.x,((transform.position.x) / 2f),0.1f), posicionDeLaCamara.y, posicionDeLaCamara.z);
        m_MainCamera.transform.position = posicionDeLaCamara;
        transform.position = new Vector3(GameManager.Instance.Target.position.x, transform.position.y, transform.position.z);

        // en este codigo no se encuentran los controles del jugador, un game manager se encarga de darle estas ordenes, entre otras como esta coroutine de abajo
    }
    #endregion

    public IEnumerator Caerse()
    {
        int i = 1;
        int j = -1;
        int contador = 0;
        while (contador < 2)
        {

            transform.rotation = Quaternion.Euler(0, i * 4, i*4);
            i = i + j;
            yield return new WaitForSeconds(0.0f);
            if (i <= -5 || i >= 5)
            {
                contador++;
                j *= -1;
            }
        }

        if(transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }       
    }
}
