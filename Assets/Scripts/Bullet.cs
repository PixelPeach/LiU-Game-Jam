using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public float zRotation;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "planet") {
            collision.gameObject.GetComponent<Planet>().healthbar.GetHurt();
            if (collision.gameObject.GetComponent<Planet>().healthbar.isDead) {
                collision.gameObject.GetComponent<Planet>().StopSimulation();

                //TODO: Detach turret from planet

                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "shield") {
            collision.gameObject.GetComponent<Shield>().GetHurt();
            Destroy(this.gameObject);
        }
    }

    void Update() {
        transform.position += transform.up * Time.deltaTime * 10.0f;

        if (transform.position.x < -9.6f || transform.position.x > 9.6f || transform.position.y < -5.1f || transform.position.y > 5.1f) {
            Destroy(this.gameObject);
        }
    }
}
