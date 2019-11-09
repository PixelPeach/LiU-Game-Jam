using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placeble : MonoBehaviour
{
    protected float angle;

    // Start is called before the first frame update
    void Start()
    {

    }
  
    protected void StickToPlanet()
    {
        float deltaX = transform.parent.position.x - transform.position.x;
        float deltaY = transform.parent.position.y - transform.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI / 2)));
    }

    void TakeDamage()
    {

    }

    void Update()
    {

    }
}
