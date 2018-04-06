using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap2 : MonoBehaviour
{
    public GameObject miniEnemigo;
    RectTransform m_RectTransform;
    private float posicionAvanzada ;

    void Start()
    {
        miniEnemigo = GameObject.FindGameObjectWithTag("EnemyTag");

        m_RectTransform = GetComponent<RectTransform>();

        posicionAvanzada = -100f;
    }

    private void Update()
    {
        posicionAvanzada += 0.25f;
        //este posicion avanzada la voy a reemplazar por un lerp de -100 a 100 en lo que termine el tiempo limite del nivel
        m_RectTransform.anchoredPosition = new Vector2(0, posicionAvanzada);
    }
}
