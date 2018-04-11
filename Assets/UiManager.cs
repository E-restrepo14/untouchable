using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public bool estaPausado = false;
    [SerializeField]
    private GameObject winSprite;
    [SerializeField]
    private GameObject looseSprite;
    [SerializeField]
    private GameObject backGround;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //==================================================

    public void Ganar()
    {       
        MostrarCosa(winSprite);
        MostrarCosa(backGround);
        estaPausado = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    public void Perder()
    {
        MostrarCosa(looseSprite);
        MostrarCosa(backGround);
        estaPausado = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.fixedTime;
    }

    public void Pausar()
    {
        estaPausado = !estaPausado;

        if (estaPausado == true)
        {
            Time.timeScale = 0.0F;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    
    public void CambiarVolumen(GameObject slider)
    {
        float volume = slider.GetComponent<Slider>().value;
        GameManager.Instance.source.volume = volume;
    }

    public void MostrarCosa(GameObject cosa)
    {
        cosa.SetActive (true);
    }
    public void OcultarCosa(GameObject cosa)
    {
        cosa.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

}

