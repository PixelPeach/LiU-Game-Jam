using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public GameObject restartText;
    public GameObject truck;
    public Healthbar healthbar;
    public int planet;
    public int maxGarbage = 5;

    public float truckStartPositionY = 2.25f;
    public float planetTurnSpeed = 45.0f;
    public float roundTime = 8.0f;

    bool simulating = false;
    float timer = 8.0f;

    private void OnDestroy() {
        restartText.SetActive(true);
    }

    public void Simulate() {
        simulating = true;
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets) {
            turret.GetComponent<Turret>().active = true;
        }
    }

    public void StopSimulation() {
        transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
        simulating = false;
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets) {
            turret.GetComponent<Turret>().active = false;
        }
        if (planet == 1) {
            GameObject[] planets = GameObject.FindGameObjectsWithTag("planet");
            
            //If player dies after StopSimulation is called this will not work.
            if (planets.Length > 1) {
                GameObject temp = Instantiate(truck, transform.position, Quaternion.identity, transform.GetChild(0));
                temp.name = "truck";
                temp.GetComponent<Truck>().planets.Add(transform.GetChild(0).gameObject);
                foreach (GameObject planet in planets) {
                    if (planet.GetComponent<Planet>().planet == 2) {
                        temp.GetComponent<Truck>().planets.Add(planet.transform.GetChild(0).gameObject);
                    }
                }
                temp.transform.localPosition = new Vector3(0, truckStartPositionY, 0);
            }
        }
    }

    void Update() {
        if (simulating) {
            timer -= Time.deltaTime;
            if (timer > 0.0f) {
                transform.Rotate(0, 0, -planetTurnSpeed * Time.deltaTime, Space.Self);
            }
            else {
                timer = roundTime;
                StopSimulation();
            }
        }
    }
}
