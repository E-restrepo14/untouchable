using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    // dentro de este script hay cuatro metodos que se llaman al comprar los items del menu de la tienda
    // este script tambien habilita en el hud los botones que indican cuando estos items estan disponibles y los deshabilita tambien
    // adicionalmente hay otros cuatro subprocesos que se llaman cuando estos items son gastados.

    public GameObject frenoPastilla;
    public GameObject frenoDisco;
    public GameObject ruedas;
    public GameObject rodamiento;

    public GameObject enemigo;

    public bool hayPastilla;
    public bool hayDisco;
    public bool hayRuedas;
    public bool hayRodamiento;


    public static ItemsManager Instance;

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
    //===========================================================================

    #region comprar items
    public void ComproPastilla()
    {
        if (hayDisco == false && hayPastilla == false)
        {
            if (GameManager.Instance.monedas >= 5)
            {
                GameManager.Instance.AlterarTotalMonedas(-5);
                frenoPastilla.GetComponent<Button>().interactable = true;
                hayPastilla = true;
            }
        }
    }

    public void ComproDisco()
    {
        if (hayDisco == false)
        {
            if (GameManager.Instance.monedas >= 20)
            {
                GameManager.Instance.AlterarTotalMonedas(-20);
                frenoDisco.GetComponent<Button>().interactable = true;
                hayDisco = true;
            }
        }
    }

    public void ComproRuedas()
    {
        if (hayRodamiento == false && hayRuedas == false)
        {
            if (GameManager.Instance.monedas >= 5)
            {
                GameManager.Instance.AlterarTotalMonedas(-5);
                ruedas.GetComponent<Button>().interactable = true;
                hayRuedas = true;
            }
        }
    }

    public void ComproRodamiento()
    {
        if (hayRodamiento == false)
        {
            if (GameManager.Instance.monedas >= 20)
            {
                GameManager.Instance.AlterarTotalMonedas(-20);
                rodamiento.GetComponent<Button>().interactable = true;
                hayRodamiento = true;
            }
        }
    }
    #endregion



    #region accionar items
    //=====================================================================
    public void gastarPastilla()
    {
        frenoPastilla.GetComponent<Button>().interactable = false;
        hayPastilla = false;
        enemigo.GetComponent<EnemyScript>().StartCoroutine("RetrocederEnemigo");
    }

    public void gastarDisco()
    {
        frenoDisco.GetComponent<Button>().interactable = false;
        enemigo.GetComponent<EnemyScript>().StartCoroutine("MeterPique");
    }

    public void gastarRuedas()
    {
        ruedas.GetComponent<Button>().interactable = false;
        hayRuedas = false;
        enemigo.GetComponent<EnemyScript>().StartCoroutine("RetrocederEnemigo");
    }

    public void gastarRodamiento()
    {
        rodamiento.GetComponent<Button>().interactable = false;
        enemigo.GetComponent<EnemyScript>().StartCoroutine("MeterPique");
    }

    #endregion

}
