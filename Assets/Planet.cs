using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    bool simulating = false;

    public void Simulate() {
        simulating = true;
    }

    void Update() {
        if (simulating) {
            transform.Rotate(0, 0, -45.0f * Time.deltaTime, Space.Self);
        }
    }
}
