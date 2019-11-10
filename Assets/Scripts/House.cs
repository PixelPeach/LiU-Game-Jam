using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Placeble
{
    // Sounds like function, rename to compostAmount and write IncreaseCompost() function
    public int increaseCompost = 1;

    void Start()
    {
        transform.eulerAngles = StickToPlanet(transform.parent.position, transform);
        transform.parent.GetComponent<Planet>().maxGarbage+= increaseCompost;
    }

}
