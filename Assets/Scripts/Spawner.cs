using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] asteroids;
    float timer;

    void Start() {
        timer = Random.Range(1.0f, 5.0f);
    }

    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0.0f) {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], transform.position, Quaternion.identity);
            timer = Random.Range(5.0f, 15.0f);
        }
    }
}
