using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject menuMenu;
    [SerializeField]
    private GameObject menuSalir;
    [SerializeField]
    private GameObject menuInstrucciones;
    [SerializeField]
    private GameObject bienvenida;
    [SerializeField]
    private GameObject hasPerdido;
    [SerializeField]
    private GameObject hasGanado;
    [SerializeField]
    private GameObject menuNivel;
    [SerializeField]
    private GameObject menuSkins;
    [SerializeField]
    private GameObject menuBicicletas;
    [SerializeField]
    private GameObject menuTienda;
    [SerializeField]
    private GameObject menuPausa;
    
    //=============================================
    private void Awake ()
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

    public void MostrarCosa(GameObject cosa)
    {
        cosa.SetActive (true);
    }
    public void OcultarCosa(GameObject cosa)
    {
        cosa.SetActive(false);
    }

    public void Pausar()
    {
       //para esta se tiene que acceder al gamemanager
    }

    public void Salir()
    {
        //para salir del a aplicacion
    }

}

