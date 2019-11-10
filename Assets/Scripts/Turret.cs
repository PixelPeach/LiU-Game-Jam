using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Placeble {

    public Rigidbody2D rb;
    public GameObject bullet;

    public float shootingSpeed = 1.5f;
    public float maxAngle = 90;
    public bool active = false;

    float targetAngle;
    bool shooting = true;

    void Start() {
        gameObject.name = "turret";
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = StickToPlanet(transform.parent.position, transform);
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
        yield return new WaitForSeconds(shootingSpeed);
        shooting = true;
    }

    //Should re-write this code
    void RotateTurret() {
        GameObject[] Planets = GameObject.FindGameObjectsWithTag("planet");

        foreach (GameObject planet in Planets) {
            //This does not do anything
            if (planet == this.transform.parent.gameObject)
            {
                continue;
            }

            float deltaXTarget = planet.transform.position.x - transform.parent.position.x;
            float deltaYTarget = planet.transform.position.y - transform.parent.position.y;
            targetAngle = Mathf.Atan2(deltaYTarget, deltaXTarget);
            this.gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -((Mathf.Rad2Deg * targetAngle) + (Mathf.Rad2Deg * (Mathf.PI / 2))));
        }

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
    }
}
