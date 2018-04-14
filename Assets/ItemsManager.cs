using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    // dentro de este script habran cuatro metodos que implican comprar los items de un solo uso y los de varios usos 
    // este tambien los muestra en el hud 

        //ojito a la funcion de iniciar nivel... si estas variables lo indican... hacer el setactive del hud de los items.     checked

    //y dentro de este script estan los metodos de activar estos items... que unicamente se accederan a estos metodos mediante el mismo hud de botones.

    //a la mecanica de meterle el nitro... se activara automaticamente cuando se deje de instanciar cosas. pero verificará desde este script si tiene permiso de hacerlo
    // si es necesario meter el pique para no perder... que salga un sprite diciendo " si no aceleras ahora, no te servirá hacerlo mas adelante... opciones lo guardaré y acelerar "

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
