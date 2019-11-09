using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Rigidbody2D rb;
    public GameObject bullet;
    float angle;

    bool shooting = true;
    public bool active = false;

    void Start() {
        gameObject.name = "turret";
        rb = GetComponent<Rigidbody2D>();
        float deltaX = transform.parent.position.x - transform.position.x;
        float deltaY = transform.parent.position.y - transform.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI/2)));
    }

    public void ActivateGravity() {
        rb.simulated = true;
        rb.AddForce(transform.forward * 10.0f);
    }

    IEnumerator Shoot() {
        shooting = false;
        GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
        temp.GetComponent<Bullet>().zRotation = Mathf.Deg2Rad * transform.localEulerAngles.z + Mathf.PI/2 ;
        yield return new WaitForSeconds(1.5f);
        shooting = true;
    }

    void Update() {
        if (shooting && active) {
            StartCoroutine(Shoot());
        }
    }
}
