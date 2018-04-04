using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Camera m_MainCamera;
    public static PlayerMovement Instance;

 
    Vector3 posicionDeLaCamara;
    
    
    private void Awake()
    {
        m_MainCamera = Camera.main;
        posicionDeLaCamara = m_MainCamera.transform.position;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //==============================================================================================================

    [SerializeField]
    Transform [] carriles;
    [SerializeField]
    float speed;

    
  
    void Update ()
    {

        posicionDeLaCamara = new Vector3 (Mathf.Lerp (posicionDeLaCamara.x,((transform.position.x) / 2f),0.1f), posicionDeLaCamara.y, posicionDeLaCamara.z);
        m_MainCamera.transform.position = posicionDeLaCamara;
//        transform.position = new Vector3 (Mathf.Lerp(transform.position.x, GameManager.Instance.Target.position.x, speed * Time.deltaTime), transform.position.y, transform.position.z);
        transform.position = new Vector3( GameManager.Instance.Target.position.x, transform.position.y, transform.position.z);


    }
 
}
