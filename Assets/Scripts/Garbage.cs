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
    float angle;

    private void Start() {
        float deltaX = transform.parent.position.x - transform.position.x;
        float deltaY = transform.parent.position.y - transform.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI / 2)));
    }

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
            GameObject obj = Instantiate(turret, transform.position, Quaternion.identity, transform.parent);
            obj.transform.eulerAngles = transform.eulerAngles;

            Destroy(this.gameObject);
            Destroy(temp);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            GameObject obj = Instantiate(shield, transform.position, Quaternion.identity, transform.parent);
            obj.transform.eulerAngles = transform.eulerAngles;

            Destroy(this.gameObject);
            Destroy(temp);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            GameObject obj = Instantiate(house, transform.position, Quaternion.identity, transform.parent);
            obj.transform.eulerAngles = transform.eulerAngles;

            Destroy(this.gameObject);
            Destroy(temp);
        }
    }

    private void OnMouseExit() {
        Destroy(temp);
    }

}
