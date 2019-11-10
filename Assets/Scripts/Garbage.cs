using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Placeble {
    //Some questionable fields
    public SpriteRenderer spriteRenderer;
    public Sprite tier2Sprite;
    public GameObject buildWindowPrefab;
    public List<GameObject> placeables = new List<GameObject>();
    public List<GameObject> tier2_placeables = new List<GameObject>();
    GameObject buildingWindow;

    private void Start() {
        transform.eulerAngles = StickToPlanet(transform.parent.position, transform);
    }

    void CheckForNeighbours() {
        GameObject[] garbageList = GameObject.FindGameObjectsWithTag("garbage");
        foreach (GameObject garbage in garbageList) {
            if (Vector2.Distance(transform.position, garbage.transform.position) < 1.0f) {
                if (garbage != gameObject) {
                    // Why are we changing garbage sprite?
                    spriteRenderer.sprite = tier2Sprite;

                    placeables = tier2_placeables;
                    Destroy(garbage);
                }
            }
        }
    }

    private void OnMouseEnter() {
        if (GameObject.Find("truck") == null) {
            CheckForNeighbours();
            buildingWindow = Instantiate(buildWindowPrefab, transform.position, Quaternion.identity);
            buildingWindow.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            buildingWindow.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnMouseOver() {
        // If truck exists, you are not able to place objects
        if (GameObject.Find("truck") == null) {
            if (Input.GetKeyUp(KeyCode.Alpha1)) {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                Instantiate(placeables[0], pos, Quaternion.identity, transform.parent);
                Destroy(this.gameObject);
                Destroy(buildingWindow);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2)) {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                Instantiate(placeables[1], pos, Quaternion.identity, transform.parent);
                Destroy(this.gameObject);
                Destroy(buildingWindow);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3)) {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                Instantiate(placeables[2], pos, Quaternion.identity, transform.parent);
                Destroy(this.gameObject);
                Destroy(buildingWindow);
            }
        }
    }

    private void OnMouseExit() {
        if (GameObject.Find("truck") == null) {
            Destroy(buildingWindow);
        }
    }

}
