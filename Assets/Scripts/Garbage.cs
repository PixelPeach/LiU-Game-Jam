using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour {

    public GameObject buildWindowPrefab;
    public GameObject turret;
    public GameObject shield;
    public GameObject house;
    //bool isUp = false;
    GameObject temp;

    void CheckForNeighbours() {
        GameObject[] garbageList = GameObject.FindGameObjectsWithTag("garbage");
        foreach (GameObject garbage in garbageList) {
            if (Vector2.Distance(transform.position, garbage.transform.position) < 1.0f) {
                if (garbage != gameObject) {
                    transform.localScale *= 1.25f;
                    Destroy(garbage);
                    /*
                    if (garbage.transform.localScale.x > transform.localScale.x) {
                        garbage.transform.localScale *= 1.25f;
                        Destroy(gameObject);
                    }
                    else {
                        transform.localScale *= 1.25f;
                        Destroy(garbage);
                    }
                    */
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
            Instantiate(turret, transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
            Destroy(temp);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Instantiate(shield, transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
            Destroy(temp);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Instantiate(house, transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
            Destroy(temp);
        }
    }

    private void OnMouseExit() {
        Destroy(temp);
    }

}
