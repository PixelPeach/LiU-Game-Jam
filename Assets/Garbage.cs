using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour {
    public GameObject buildWindowPrefab;
    public GameObject turret;
    bool isUp = false;
    GameObject temp;

    void Start() {

    }

    private void OnMouseUp() {
        //TODO: REMOVE LATER
        Instantiate(turret, transform.position, Quaternion.identity, transform.parent);
        Destroy(this.gameObject);

        if (!isUp) {
            temp = Instantiate(buildWindowPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
            temp.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            temp.transform.localScale = new Vector3(2, 1, 1);
            isUp = true;
        }
        else {
            Destroy(temp);
            isUp = false;
        }
    }

    void Update() {

    }
}
