using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    bool simulating = false;

    public void Simulate() {
        simulating = true;
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets) {
            turret.GetComponent<Turret>().active = true;
        }
    }

    public void StopSimulation() {
        simulating = false;
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets) {
            turret.GetComponent<Turret>().active = false;
        }
    }

    void Update() {
        if (simulating) {
            transform.Rotate(0, 0, -45.0f * Time.deltaTime, Space.Self);
        }
    }
}
