using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    

    public static GameManager Instance;
    public AudioClip Theme;
	public GameObject enemigo;
	public int turbo = 0;
    public int monedas;
    public int levelnum;

    [SerializeField]
    private GameObject botonNivel2;
    [SerializeField]
    private GameObject botonNivel3;

    [SerializeField]
    private Image turboSprite;
    [SerializeField]
    private Image turboSprite2;
    [SerializeField]
    private Image t2;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text coinText;
    public AudioSource source;
    public float tiempoLimite = 170f;

    int seleccionar;

   

	private void Awake()
	{
		enemigo = GameObject.FindGameObjectWithTag("EnemyTag");
        source = GetComponent<AudioSource>();
        source.clip =Theme;
        source.volume = 0.5f;
        source.Play();

		if (Instance == null) 
		{
			Instance = this;
		} 
		else 
		{
			Destroy (this);
		}

        seleccionar = 1;
        
    }


    public Transform[] carriles;
    [SerializeField]
    float speed;   
    public Transform Target;

    public void SelectNivel(int n)
    {
        levelnum = n;
    }

    public void Desbloquearnivel()
    {
        if (levelnum == 1)
        {
            botonNivel2.GetComponent<Button>().interactable = true;
        }
        if (levelnum == 2)
        {
            botonNivel3.GetComponent<Button>().interactable = true;
        }

    }

    //el argumento proximo de este void es el numero de nivel que va a iniciar
    public void IniciarNivel()
    {
        tiempoLimite = 30f;
        Instanciador.Instance.NextTime = 0.15f-(0.03f*(levelnum-1));
        Instanciador.Instance.estaJugando = true;
        enemigo.transform.position = new Vector3(-2f,0.512f,0.595f);
    }

    public void AlterarTotalMonedas(int valor)
    {
        monedas += valor;
        coinText.text = "= " + monedas.ToString();
    }

    #region almacenar turbo 
    public void SubirTurbo()
	{
        if (turbo <= 9)
        {
            turbo++;
        }
        if (turbo > 3)
        {
            turboSprite.enabled = true;
            t2.enabled = true;
        }
        if (turbo > 7)
        {
            turboSprite2.enabled = true;
        }
    }
    #endregion

    #region void update de get axis y activar turbo 
    private void Update()
	{
        tiempoLimite -= Time.deltaTime;
        if (tiempoLimite >0)
        {
            timeText.text = "Timer: " + tiempoLimite.ToString("f0");
        }
        if (tiempoLimite < 1 && tiempoLimite > 0.9f)
        {
            print("se acavo el tiempo");
            if (enemigo.transform.position.z < 0)
            {
                UiManager.Instance.Ganar();
            }
            else
            {
                UiManager.Instance.Perder();
            }
            tiempoLimite = 0.88f;
        }

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			seleccionar = 0;

		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			seleccionar = 1;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			seleccionar = 2;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			seleccionar = 3;
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			if (seleccionar > 0) {
				seleccionar = (seleccionar - 1);
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			if (seleccionar < 3) {
				seleccionar = (seleccionar + 1);
			}
		}

		if (Input.GetKeyDown (KeyCode.T)) {
            if (UiManager.Instance.estaPausado == false)
            {
                if (turbo > 3)
                {
                    enemigo.GetComponent<EnemyScript>().StartCoroutine("MeterPique");
                    turbo -= 4;
                }
                if (turbo < 3)
                {
                    turboSprite.enabled = false;
                    t2.enabled = false;
                }
                if (turbo < 7)
                {
                    turboSprite2.enabled = false;
                }
            }
        }

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (seleccionar > 0) {
				seleccionar = (seleccionar - 1);
			}
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (seleccionar < 3) {
				seleccionar = (seleccionar + 1);
			}
		}
        

		Target = carriles [seleccionar];


	}
    #endregion

    //este parte era para ser llamado con un nodo, recibia la posicion directamente
    // la idea era para que el juego estuviera para celular, pero ni de chiste aguantaría ahi
    //    public void SeleccionarCarril(int indiceInt)
    //  {

    //    seleccionar = indiceInt;
    //}
}
