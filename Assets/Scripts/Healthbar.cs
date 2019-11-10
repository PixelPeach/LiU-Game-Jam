using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {

    public Sprite[] cracks;
    public SpriteMask mask;

    public float health = 1.0f;
    public bool isDead = false;

    public void GetHurt() {
        if (health > 0.0f) {
            health -= 0.075f;
        }
        else {
            isDead = true;
        }

        if (health > 0.75f && health < 0.85f) { mask.sprite = cracks[0]; }
        if (health > 0.55f && health < 0.75f) { mask.sprite = cracks[1]; }
        if (health > 0.35f && health < 0.45f) { mask.sprite = cracks[2]; }
        if (health > 0.15f && health < 0.25f) { mask.sprite = cracks[3]; }
    }

}
