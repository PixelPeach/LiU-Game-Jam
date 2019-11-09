using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Placeble {

    int health = 2;

    public void GetHurt() {
        health--;
        gameObject.transform.localScale *= 0.75f;
        if (health < 0) {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    
}
