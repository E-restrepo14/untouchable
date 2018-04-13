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
//  este float speed era necesario para hacer una transicion del jugador desde una posicion a otra, pero como laguea mucho la voy a quitar
//    [SerializeField]
//    float speed;
    
    void Update ()
    {
       

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

        posicionDeLaCamara = new Vector3 (Mathf.Lerp (posicionDeLaCamara.x,((transform.position.x) / 2f),0.1f), posicionDeLaCamara.y, posicionDeLaCamara.z);
        m_MainCamera.transform.position = posicionDeLaCamara;
        //transform.position = new Vector3 (Mathf.Lerp(transform.position.x, GameManager.Instance.Target.position.x, speed * Time.deltaTime), transform.position.y, transform.position.z);
        transform.position = new Vector3(GameManager.Instance.Target.position.x, transform.position.y, transform.position.z);
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
