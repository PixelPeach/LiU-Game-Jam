using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {

    public float health = 1.0f;

    public void GetHurt() {
        if (health > 0.0f) {
            health -= 0.1f;
            transform.localScale = new Vector2(health, transform.localScale.y);
        }
    }

}
