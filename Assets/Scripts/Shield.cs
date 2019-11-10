using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Placeble {

    public float size = 1;
    public float scaleMultiplier = 0.75f;
    public int startHealth = 2;
    int health;

    private void Start()
    {
        transform.parent.eulerAngles = StickToPlanet(transform.parent.parent.position, transform.parent);
        gameObject.transform.localScale *= size;
        health = startHealth;
    }


    public void GetHurt() {
        health--;
        gameObject.transform.localScale *= scaleMultiplier;
        if (health < 0) {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    
}
