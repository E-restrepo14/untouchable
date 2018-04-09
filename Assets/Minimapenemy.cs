using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapenemy : MonoBehaviour
{

    public GameObject miniEnemigo;
    RectTransform m_RectTransform;
    private float minienemyposition;

    void Start()
    {
        miniEnemigo = GameObject.FindGameObjectWithTag("EnemyTag");

        m_RectTransform = GetComponent<RectTransform>();

        minienemyposition = 0.5f;
    }

    private void Update()
    {
        minienemyposition = (miniEnemigo.transform.position.z);

        m_RectTransform.anchoredPosition = new Vector2(-45f, minienemyposition);
    }
}
