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
    public int monedas = 4;
    public int levelnum;

	private int i = 0;

    public GameObject botonNivel2;
    public GameObject botonNivel3;

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

    public Transform[] carriles;
    [SerializeField]
    float speed;
    public Transform Target;

    // en este script se almacenan valores muy importantes del juego como son las monedas, el tiempo limite del nivel, la cantidad de segundos de espera entre cada instancia de un 
    //obstaculo y adorno en la escena y tambien esta clase guarda muchos subprocesos que implica cambiar el valor de muchas variables aca almacenadas.

    private void Awake()
	{
		if (Instance == null) 
		{
			Instance = this;
		} 
		else 
		{
			Destroy (this);
		}

        seleccionar = 1;
        enemigo = GameObject.FindGameObjectWithTag("EnemyTag");
        source = GetComponent<AudioSource>();
        source.clip = Theme;
        source.volume = 0.5f;
        source.Play();
    }

    public void SelectNivel(int n)
    {
        levelnum = n;
    }

    
    public void IniciarNivel()
    {
        tiempoLimite = 50f;
		Instanciador.Instance.NextTime = (0.15f*2)-(0.03f*(levelnum-1));
        Instanciador.Instance.estaJugando = true;
        enemigo.transform.position = new Vector3(-2f,0.512f,0.595f);
        i = 0;
        if (ItemsManager.Instance.hayPastilla == true)
        {
            ItemsManager.Instance.frenoPastilla.GetComponent<Button>().interactable = true;
        }
        if (ItemsManager.Instance.hayDisco == true)
        {
            ItemsManager.Instance.frenoDisco.GetComponent<Button>().interactable = true;
        }
        if (ItemsManager.Instance.hayRuedas == true)
        {
            ItemsManager.Instance.ruedas.GetComponent<Button>().interactable = true;
        }
        if (ItemsManager.Instance.hayRodamiento == true)
        {
            ItemsManager.Instance.rodamiento.GetComponent<Button>().interactable = true;
        }
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

    // esta parte es el update que verifica las acciones del jugador y en base a estas le ordena a otros script como el playercontroler mover al personaje por ejemplo
    #region void update de get axis y activar turbo 
    private void Update()
	{
        tiempoLimite -= Time.deltaTime;
        if (tiempoLimite >0)
        {
            timeText.text = "Timer: " + tiempoLimite.ToString("f0");
        }
        if (tiempoLimite < 1 && tiempoLimite > 0)
        {
			i ++;

			if (i == 1)
			{
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
}
