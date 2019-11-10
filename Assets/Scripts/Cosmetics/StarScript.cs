using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public Vector2 Speed = new Vector2(0.0004f,0.00015f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer.size = Renderer.size + Speed;
    }
}
