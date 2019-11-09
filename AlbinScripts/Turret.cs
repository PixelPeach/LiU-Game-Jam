using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
    float angle;
    float TargetAngle;
    public float MaxAngle = 90;
    bool shooting = true;
    public bool active = false;

    void Start() {
        float deltaX = transform.parent.position.x - transform.position.x;
        float deltaY = transform.parent.position.y - transform.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI/2)));
    }

    IEnumerator Shoot() {
        shooting = false;
        GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
        temp.transform.rotation = transform.GetChild(0).rotation;
        temp.GetComponent<Bullet>().zRotation = Mathf.Deg2Rad * transform.localEulerAngles.z + Mathf.PI/2 ;
        yield return new WaitForSeconds(1.5f);
        shooting = true;
    }

    void Update() {
        //if (Mathf.Abs())
        {
            GameObject[] Planets = GameObject.FindGameObjectsWithTag("planet");
            foreach (GameObject planet in Planets)
            {
                if (planet == this.transform.parent.gameObject) //check if the planet is the parent
                {
                    continue;
                }
                float deltaXTarget = planet.transform.position.x - transform.parent.position.x;
                float deltaYTarget = planet.transform.position.y - transform.parent.position.y;
                TargetAngle = Mathf.Atan2(deltaYTarget, deltaXTarget);
                this.gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -((Mathf.Rad2Deg * TargetAngle) + (Mathf.Rad2Deg * (Mathf.PI / 2))));

            }
            float deltaX = transform.parent.position.x - transform.position.x;
            float deltaY = transform.parent.position.y - transform.position.y;
            angle = Mathf.Atan2(deltaY, deltaX);
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI / 2)));
        }
        
        if (Mathf.Abs(this.gameObject.transform.eulerAngles.z - this.gameObject.transform.GetChild(0).transform.eulerAngles.z) < MaxAngle)
        {
            if (shooting && active)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            //gameObject.transform.GetChild(0).transform.eulerAngles = Vector3.Lerp(gameObject.transform.GetChild(0).transform.eulerAngles, transform.eulerAngles, 1.5f);
            //gameObject.transform.GetChild(0).transform.eulerAngles = Vector3.MoveTowards(gameObject.transform.GetChild(0).transform.eulerAngles, transform.eulerAngles, 1.5f);
            gameObject.transform.GetChild(0).transform.eulerAngles = transform.eulerAngles;
        }
    }
}
