using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    //This script is obsolete, wrote another one

    public SpriteRenderer renderer;

    public Vector2 Speed = new Vector2(0.0004f,0.00015f);

    void Update()
    {
        //Could write it as Renderer.size += Speed instead
        renderer.size = renderer.size + Speed;
    }
}
