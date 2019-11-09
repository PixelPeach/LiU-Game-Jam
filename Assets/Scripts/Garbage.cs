﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour {
    public GameObject buildWindowPrefab;
    public GameObject turret;
    public GameObject shield;
    bool isUp = false;
    GameObject temp;

    void Start() {

    }

    private void OnMouseEnter() {
        temp = Instantiate(buildWindowPrefab, transform.position, Quaternion.identity, transform);
        temp.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 2, transform.localPosition.z);
        temp.transform.localScale = new Vector3(10f, 10f, 10f);
    }

    private void OnMouseOver() {
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Instantiate(turret, transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Instantiate(shield, transform.position, Quaternion.identity, transform.parent);
            Destroy(this.gameObject);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Debug.Log("Bought 3");
        }
    }

    private void OnMouseExit() {
        Destroy(temp);
    }
    
}
