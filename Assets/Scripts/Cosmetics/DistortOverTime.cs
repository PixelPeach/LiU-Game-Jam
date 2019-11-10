using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistortOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float animationSpeed = 2f;
    private float timer = 0;

    void Start()
    {
    }

    void Update()
    {
        timer += 0.01f;
        float innerscaleX = 0.15f + (float)((Mathf.Sin((float)(timer * animationSpeed))) * 0.008f);
        float innerscaleY = 0.15f + (float)((Mathf.Sin((float)(timer * animationSpeed + Mathf.PI))) * 0.01f);

        transform.localScale = new Vector3(-innerscaleX, innerscaleY, 1);
    }
}
