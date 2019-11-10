using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Placeble {

    public GameObject dust;
    public float size = 1;
    public float scaleMultiplier = 0.75f;

    public bool tier2;

    private void Start()
    {
        if (tier2) {
            Regenerate();
        }
        transform.parent.eulerAngles = StickToPlanet(transform.parent.parent.position, transform.parent);
        dustPrefab = dust;
        gameObject.transform.localScale *= size;
    }


    public override void GetHurt() {
        health--;
        gameObject.transform.localScale *= scaleMultiplier;
        if (health < 0) {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    
}
