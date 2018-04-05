using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    

    public static GameManager Instance;
    public AudioClip Theme;
	public GameObject Enemigo;
	public int turbo = 0;



	int seleccionar;

	private void Awake()
	{
		Enemigo = GameObject.FindGameObjectWithTag("EnemyTag");
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip =Theme;
        audio.volume = 0.3f;
        audio.Play();

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

	public void SubirTurbo()
	{
		turbo++;
	}

    private void Update()
	{
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
			if (turbo >3) {
				Enemigo.GetComponent<EnemyScript>().StartCoroutine("MeterPique");
				turbo-= 4;
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

    //este parte era para ser llamado con un nodo, recibia la posicion directamente
// la idea era para que el juego estuviera para celular, pero ni de chiste aguantaría ahi
//    public void SeleccionarCarril(int indiceInt)
  //  {
        
    //    seleccionar = indiceInt;
    //}
}
