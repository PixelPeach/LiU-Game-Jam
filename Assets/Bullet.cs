using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 0.1f;

    [HideInInspector]
    public float zRotation;

    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x + speed*Mathf.Cos(zRotation), transform.position.y + speed * Mathf.Sin(zRotation));
        transform.position = pos;
    }
}
