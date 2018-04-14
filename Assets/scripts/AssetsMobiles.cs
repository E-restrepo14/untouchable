using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsMobiles : MonoBehaviour {

    [HideInInspector]
    public float speed = -8f;
    public AudioClip privateAudio;
    public GameObject Enemigo;

    public AudioSource source;

    // esta clase se creó para almacenar comportamientos que tienen en comun varias clases como son obstaculomedio, obstaculogrande y la moneda
	public void Awake ()
    {
        source = GetComponent<AudioSource>();
        Enemigo = GameObject.FindGameObjectWithTag("EnemyTag");

    }

    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }


    public void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }

    }

    public void Sonar (AudioClip Audioageno)
    {
        source.PlayOneShot(Audioageno,Random.Range(0.7f,1.0f));
    }

   



}
