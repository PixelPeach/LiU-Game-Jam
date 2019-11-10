using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject planetParts;
    public Vector2 startPos;

    [HideInInspector]
    public float zRotation;
    public float bulletSpeed = 10.0f;
    public float safeShootArea = 3.0f;

    public float yOffscreen = 5.1f;
    public float xOffscreen = 9.6f;

    public List<Vector3> planetPositions = new List<Vector3>();

    private void Start() {
        planetPositions.Add(new Vector3(-8, 0, -1));
        planetPositions.Add(new Vector3(0, 0, -1));
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "planet") {
            collision.gameObject.GetComponent<Planet>().healthbar.GetHurt();
            if (collision.gameObject.GetComponent<Planet>().healthbar.isDead) {
                collision.gameObject.GetComponent<Planet>().StopSimulation();

                Vector3 pos = new Vector3(0, 0, 0);
                if (collision.gameObject.GetComponent<Planet>().planet == 1) { pos = planetPositions[0]; }
                else if (collision.gameObject.GetComponent<Planet>().planet == 2) { pos = planetPositions[1]; }
                Instantiate(planetParts, pos, Quaternion.identity);

                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "shield") {
            if (Vector3.Distance(startPos, collision.transform.position) > safeShootArea) {
                collision.gameObject.GetComponent<Shield>().GetHurt();
                Destroy(this.gameObject);
            }
        }
    }

    void Update() {
        transform.position += transform.up * Time.deltaTime * bulletSpeed;

        if (transform.position.x < -xOffscreen || transform.position.x > xOffscreen || transform.position.y < -yOffscreen || transform.position.y > yOffscreen) {
            Destroy(this.gameObject);
        }
    }
}
