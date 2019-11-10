using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistortOverTime : MonoBehaviour
{
    public float animationSpeed = 2f;
    private float timer = 0;
    public float xScale = 1;
    public float yScale = 1;
    public float effectAmplitude = 1;

    void Update()
    {
        //Increase with Time.deltaTime and scale with multiplier field.
        timer += 0.01f;

        //Make 0.15f float offset
        //No need to cast as floats because Sin function return floats and fields already float.
        float innerscaleX = 0.15f + (Mathf.Sin((timer * animationSpeed))) * 0.008f* effectAmplitude;

        //Do the same thing here
        float innerscaleY = 0.15f + (float)((Mathf.Sin((float)(timer * animationSpeed + Mathf.PI))) * 0.01f* effectAmplitude);

        //Use Vector2 if youre not going to change the z-axis
        transform.localScale = new Vector3(-(innerscaleX* xScale), innerscaleY*yScale, 1);
    }
}
