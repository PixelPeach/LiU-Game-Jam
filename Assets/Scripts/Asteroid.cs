using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    SpriteRenderer sr;
    Vector3 direction;
    float movementSpeed = 2.5f;
    float rotationSpeed = 45f;
    float fadeTimer = 10.0f;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        transform.localScale *= Random.Range(1.0f, 2.5f);
        direction = Random.insideUnitCircle.normalized;
    }

    void Update() {
        transform.position += direction * Time.deltaTime * movementSpeed;
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);

        fadeTimer -= Time.deltaTime;
        if (fadeTimer <= 0.0f) {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - Time.deltaTime * 0.5f);
            if (sr.color.a <= 0.0f) {
                Destroy(gameObject);
            }
        }
    }
}
