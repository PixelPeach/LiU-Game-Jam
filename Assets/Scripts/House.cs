using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Placeble
{
    public int increaseCompost = 1;
    void Start()
    {
        transform.eulerAngles = StickToPlanet(transform.parent.position, transform);
        transform.parent.GetComponent<Planet>().maxGarbage+= increaseCompost;
    }

}
