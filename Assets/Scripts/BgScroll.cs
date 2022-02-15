using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public Renderer meshRender;
    public float speed = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
            Vector2 offset = meshRender.material.mainTextureOffset;      // calling offset property with refrences
         offset = offset + new Vector2(0, speed * Time.deltaTime);       //updating offset /s
        
             meshRender.material.mainTextureOffset = offset;  // increment of offset using offset since offset var is used
        */
        meshRender.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);

    }
}
