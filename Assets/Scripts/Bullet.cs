using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject planetParts;
    public Vector2 startPos;

    [HideInInspector]
    public float zRotation;

    private void Start() {
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "planet") {
            collision.gameObject.GetComponent<Planet>().healthbar.GetHurt();
            if (collision.gameObject.GetComponent<Planet>().healthbar.isDead) {
                collision.gameObject.GetComponent<Planet>().StopSimulation();

                Vector3 pos = new Vector3(0, 0, 0);
                if (collision.gameObject.GetComponent<Planet>().planet == 1) { pos = new Vector3(-8, 0, -1); }
                else if (collision.gameObject.GetComponent<Planet>().planet == 2) { pos = new Vector3(0, 0, -1); }
                Instantiate(planetParts, pos, Quaternion.identity);

                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "shield") {
            if (Vector3.Distance(startPos, collision.transform.position) > 3.0f) {
                collision.gameObject.GetComponent<Shield>().GetHurt();
                Destroy(this.gameObject);
            }
        }
    }

    void Update() {
        transform.position += transform.up * Time.deltaTime * 10.0f;

        if (transform.position.x < -9.6f || transform.position.x > 9.6f || transform.position.y < -5.1f || transform.position.y > 5.1f) {
            Destroy(this.gameObject);
        }
    }
}
