using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsMobiles : MonoBehaviour {

    [HideInInspector]
    public float speed = -8f;
    public AudioClip privateAudio;
    public GameObject Enemigo;

    public AudioSource source;


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

    public IEnumerator Realentizar()
    {
        Time.timeScale = 0.7F;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1.0F;

    }



}
