using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Camera m_MainCamera;
    Vector3 posicionDeLaCamara;
    
    
    private void Awake()
    {
        m_MainCamera = Camera.main;
        posicionDeLaCamara = m_MainCamera.transform.position;
    }
    //==============================================================================================================

    #region Movimiento 
    [SerializeField]
    Transform [] carriles;
    // este float speed era necesario para hacer una transicion del jugador desde una posicion a otra, pero como laguea mucho la voy a quitar
//    [SerializeField]
//    float speed;
    
    void Update ()
    {

        posicionDeLaCamara = new Vector3 (Mathf.Lerp (posicionDeLaCamara.x,((transform.position.x) / 2f),0.1f), posicionDeLaCamara.y, posicionDeLaCamara.z);
        m_MainCamera.transform.position = posicionDeLaCamara;
        //transform.position = new Vector3 (Mathf.Lerp(transform.position.x, GameManager.Instance.Target.position.x, speed * Time.deltaTime), transform.position.y, transform.position.z);
        transform.position = new Vector3(GameManager.Instance.Target.position.x, transform.position.y, transform.position.z);

        VerificarDistancia();

    }
    #endregion
    
    public Transform distanciaEnemigo;

    void VerificarDistancia()
    {
     //   if (distanciaEnemigo)
   //     {
          //  float dist = Vector3.Distance(distanciaEnemigo.position, transform.position);
        //    print("Distance to other: " + dist);
      //  }
    }
    

}
