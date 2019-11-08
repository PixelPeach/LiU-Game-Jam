using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
    float angle;

    private bool shooting = true;

    void Start() {
        float deltaX = transform.parent.position.x - transform.position.x;
        float deltaY = transform.parent.position.y - transform.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);
    }

    IEnumerator Shoot() {
        shooting = false;
        GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().zRotation = (Mathf.Rad2Deg * transform.rotation.z)*2 + Mathf.PI;
        yield return new WaitForSeconds(1.5f);
        shooting = true;
    }

    void Update() {
        if (shooting) {
            StartCoroutine(Shoot());
        }
    }
}
