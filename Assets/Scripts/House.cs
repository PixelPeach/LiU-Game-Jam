using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Placeble
{
    // Start is called before the first frame update
    void Start()
    {
        StickToPlanet();
        transform.parent.GetComponent<Planet>().maxGarbage++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
