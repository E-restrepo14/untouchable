using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
  
    [SerializeField]
    private float cloudsSpeed;
    [SerializeField]
    private Material privateMaterial;

    // Update is called once per frame
    void Update ()
    {

        Vector2 newOffset = privateMaterial.mainTextureOffset;
        newOffset.y += cloudsSpeed * Time.deltaTime;
        //newOffset.x += cloudsSpeed * Time.deltaTime;
        privateMaterial.mainTextureOffset = newOffset;
        
    }


}
