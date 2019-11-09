using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public GameObject truck;
    public int planet;
    bool simulating = false;

    public void Simulate() {
        simulating = true;
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets) {
            turret.GetComponent<Turret>().active = true;
        }
    }

    public void StopSimulation() {
        transform.GetChild(0).eulerAngles = new Vector3(0,0,0);
        simulating = false;
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets) {
            turret.GetComponent<Turret>().active = false;
        }
        if (planet == 1) {
            GameObject temp = Instantiate(truck, transform.position, Quaternion.identity, transform.GetChild(0));
            temp.GetComponent<Truck>().planets.Add(transform.GetChild(0).gameObject);
            GameObject[] planets = GameObject.FindGameObjectsWithTag("planet");
            foreach (GameObject planet in planets) {
                if (planet.GetComponent<Planet>().planet == 2) {
                    temp.GetComponent<Truck>().planets.Add(planet.transform.GetChild(0).gameObject);
                }
            }
            temp.transform.localPosition = new Vector3(0, 2.25f, 0);
        }
    }

    void Update() {
        if (simulating) {
            transform.Rotate(0, 0, -45.0f * Time.deltaTime, Space.Self);
        }
    }
}
