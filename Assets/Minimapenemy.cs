using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapenemy : MonoBehaviour
{
    // este script lo posee una imagen del canvas que sirve a modo de indicador en el hud, sobre que tan adelante esta el enemigo con respecto a la posicion del jugador,  

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
		if ( minienemyposition < 11f)
		{
        m_RectTransform.anchoredPosition = new Vector2(-45f, minienemyposition);
		}
	}
}
