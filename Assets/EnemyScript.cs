using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector3 EnemyPosition;
    public GameObject pauseSprite;
    
	int i = -4;
	int j = -1;
	int contador = 0;

    private void Start()
    {
        EnemyPosition = transform.position;
        UiManager.Instance.Pausar();
    }
 
	private void Update()
	{
		if (UiManager.Instance.estaPausado == false)
		{
			transform.rotation = Quaternion.Euler(0, 0, i*2);
			i = i + j;
			if (i <= -5 || i >= 5)
			{
				contador++;
				j *= -1;
			}
		}
	}
    

    public IEnumerator AvanzarEnemigo()
    {
		int contador = 0;
        
		while (contador < 5)
		{
            UiManager.Instance.OcultarCosa(pauseSprite);
            Camera.main.fieldOfView = (Camera.main.fieldOfView - 1);
            //Time.timeScale -= 0.02f;
            transform.Translate(0, 0, 0.2f);
           
            
			yield return new WaitForSeconds(0.0f);
			contador++;
		} 

		int contador2 = 0;
		while (contador2 < 5) 
		{
            UiManager.Instance.OcultarCosa(pauseSprite);
            Camera.main.fieldOfView = (Camera.main.fieldOfView + 1);
            //Time.timeScale += 0.02f;
            yield return new WaitForSeconds(0.0f);

			contador2++;
		}
        UiManager.Instance.MostrarCosa(pauseSprite);


    }

    public IEnumerator AdelantarEnemigo()
    {
        int contador = 0;
        
        while (contador < 8)
        {
            UiManager.Instance.OcultarCosa(pauseSprite);
            transform.Translate(0, 0, 0.05f);
            yield return new WaitForSeconds(0.0f);

            contador++;
        }
        UiManager.Instance.MostrarCosa(pauseSprite);
    }

    public IEnumerator RetrocederEnemigo()
    {
		int contador = 0;
        
        while (contador < 5)
		{
            UiManager.Instance.OcultarCosa(pauseSprite);
            Camera.main.fieldOfView = (Camera.main.fieldOfView - 1);
            //Time.timeScale -= 0.02f;
            transform.Translate(0, 0, -0.1f);
			yield return new WaitForSeconds(0.0f);
			contador++;
		} 

		int contador2 = 0;
		while (contador2 < 5) 
		{
            UiManager.Instance.OcultarCosa(pauseSprite);
            Camera.main.fieldOfView = (Camera.main.fieldOfView + 1);
            //Time.timeScale += 0.02f;
            yield return new WaitForSeconds(0.0f);

			contador2++;
		}
        UiManager.Instance.MostrarCosa(pauseSprite);
    }

	public IEnumerator MeterPique()
	{
		int contador = 0;
        
        while (contador < 30)
		{
            UiManager.Instance.OcultarCosa(pauseSprite);
            Camera.main.fieldOfView = (Camera.main.fieldOfView + 1);            
            //Time.timeScale += 0.01f;
            transform.Translate(0, 0, -0.1f);
			yield return new WaitForSeconds(0.0f);

			contador++;
		} 

		int contador2 = 0;
		while (contador2 < 30) 
		{
            UiManager.Instance.OcultarCosa(pauseSprite);
            Camera.main.fieldOfView = (Camera.main.fieldOfView - 1);
            //Time.timeScale -= 0.01f;
            yield return new WaitForSeconds(0.0f);

			contador2++;
		}
        UiManager.Instance.MostrarCosa(pauseSprite);
    }

}
