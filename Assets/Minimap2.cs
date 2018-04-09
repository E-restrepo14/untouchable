using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap2 : MonoBehaviour
{
    public GameObject miniEnemigo;
    RectTransform m_RectTransform;
    private float t;
    private float t2;
    private float t3;
    void Start()
    {
        miniEnemigo = GameObject.FindGameObjectWithTag("EnemyTag");

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
