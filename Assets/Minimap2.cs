using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap2 : MonoBehaviour
{
    RectTransform m_RectTransform;
    private float t;
    private float t2;
    private float t3;
   
    //este script se encarga de mover un empty padre de dos sprites que representan la posicion del jugador y el enemigo en la pista, y a medida que el tiempo limite para ganar le nivel se va disminuyendo...
    // el game object poseedor de este script se mueve por el rect transform desde una posicion hasta otro dependiendo de un tiempo que se le de para realizar esta accion
    
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        t = GameManager.Instance.tiempoLimite;
    }

    private void Update()
    {
        t2 = GameManager.Instance.tiempoLimite;
        
        t3 = t2/t;
        
        m_RectTransform.anchoredPosition = new Vector2(0, Mathf.Lerp(100, -100, t3));
    }
}
