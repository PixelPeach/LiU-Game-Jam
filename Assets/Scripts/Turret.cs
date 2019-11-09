using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Placeble {

    public Rigidbody2D rb;
    public GameObject bullet;

    public float maxAngle = 90;
    float targetAngle;

    bool shooting = true;
    public bool active = false;

    void Start() {
        gameObject.name = "turret";
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void ActivateGravity() {
        rb.simulated = true;
        rb.AddForce(transform.forward * 10.0f);
    }

    IEnumerator Shoot() {
        shooting = false;
        GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
        temp.transform.eulerAngles = transform.GetChild(0).eulerAngles;
        temp.GetComponent<Bullet>().zRotation = Mathf.Deg2Rad * transform.localEulerAngles.z + Mathf.PI / 2;
        yield return new WaitForSeconds(1.5f);
        shooting = true;
    }

    void RotateTurret() {
        GameObject[] Planets = GameObject.FindGameObjectsWithTag("planet");
        foreach (GameObject planet in Planets) {
            if (planet == this.transform.parent.gameObject) //check if the planet is the parent
            {
                continue;
            }
            float deltaXTarget = planet.transform.position.x - transform.parent.position.x;
            float deltaYTarget = planet.transform.position.y - transform.parent.position.y;
            targetAngle = Mathf.Atan2(deltaYTarget, deltaXTarget);
            this.gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -((Mathf.Rad2Deg * targetAngle) + (Mathf.Rad2Deg * (Mathf.PI / 2))));

        }
        float deltaX = transform.parent.position.x - transform.position.x;
        float deltaY = transform.parent.position.y - transform.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI / 2)));

        if (Mathf.Abs(this.gameObject.transform.eulerAngles.z - this.gameObject.transform.GetChild(0).transform.eulerAngles.z) < maxAngle) {
            if (shooting && active) {
                StartCoroutine(Shoot());
            }
        }
        else {
            gameObject.transform.GetChild(0).transform.eulerAngles = transform.eulerAngles;
        }
    }

    void Update() {
        RotateTurret();
        /*
        if (shooting && active) {
            StartCoroutine(Shoot());
        }
        */
    }
}
