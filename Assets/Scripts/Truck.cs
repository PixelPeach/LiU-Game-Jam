

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour {
    public List<GameObject> planets = new List<GameObject>();
    public GameObject garbagePrefab;
    public int maxGarbage;
    int garbage;
    int index = 0;

    Transform pivot;

    float timer;

    void Start() {
        pivot = planets[index].transform;
        ResetTransform();
    }

    void ResetTransform() {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.localPosition = new Vector3(0, 2.25f, -1);
    }

    void ChangePlanet() {
        if (index == planets.Count - 1) {
            Destroy(this.gameObject);
        }
        else {
            index++;
            transform.parent = planets[index].transform;
            ResetTransform();
            pivot = planets[index].transform;
            garbage = 0;
        }
    }

    float GetRandomTimer() {
        return Random.Range(1.0f, 2.5f);
    }

    void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0.0f && garbage < maxGarbage) {
            Instantiate(garbagePrefab, transform.position, Quaternion.identity, transform.parent.parent);
            garbage++;
            timer = GetRandomTimer();
        }
        if (garbage == maxGarbage) {
            ChangePlanet();
        }
        pivot.Rotate(0, 0, -45.0f * Time.deltaTime, Space.Self);
    }
}
