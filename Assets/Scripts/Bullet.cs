using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //float speed = 0.1f;

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

        /*
        Vector2 pos = new Vector2(transform.position.x + speed * Mathf.Cos(zRotation), transform.position.y + speed * Mathf.Sin(zRotation));
        transform.position = pos;
        */

        if (transform.position.x < -9.6f || transform.position.x > 9.6f || transform.position.y < -5.1f || transform.position.y > 5.1f) {
            Destroy(this.gameObject);
        }
    }
}
