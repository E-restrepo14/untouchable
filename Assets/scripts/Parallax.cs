using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    // esta script es para simular el avance del personaje... moviendo la textura del piso hacia una direccion, 
     
    [SerializeField]
    private float cloudsSpeed;
    [SerializeField]
    private Material privateMaterial;

    void Update ()
    {

        Vector2 newOffset = privateMaterial.mainTextureOffset;
        newOffset.y += cloudsSpeed * Time.deltaTime;
        //newOffset.x += cloudsSpeed * Time.deltaTime;
        privateMaterial.mainTextureOffset = newOffset;
        
    }


}
