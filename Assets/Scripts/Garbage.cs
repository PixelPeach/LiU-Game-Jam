using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Placeble {

    public GameObject buildWindowPrefab;
    public List<GameObject> placeables = new List<GameObject>();
    GameObject temp;

    private void Start() {
        transform.eulerAngles = StickToPlanet(transform.parent.position, transform);
    }

    void CheckForNeighbours() {
        GameObject[] garbageList = GameObject.FindGameObjectsWithTag("garbage");
        foreach (GameObject garbage in garbageList) {
            if (Vector2.Distance(transform.position, garbage.transform.position) < 1.0f) {
                if (garbage != gameObject) {
                    transform.localScale *= 1.25f;
                    Destroy(garbage);
                }
            }
        }
    }

    private void OnMouseEnter() {
        CheckForNeighbours();
        temp = Instantiate(buildWindowPrefab, transform.position, Quaternion.identity);
        temp.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        temp.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseOver() {
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Instantiate(placeables[0], transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
            Destroy(temp);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Instantiate(placeables[1], transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
            Destroy(temp);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Instantiate(placeables[2], transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
            Destroy(temp);
        }
    }

    private void OnMouseExit() {
        Destroy(temp);
    }

}
