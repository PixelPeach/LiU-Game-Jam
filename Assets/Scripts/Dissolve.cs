using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    SpriteRenderer sr;
    Vector3 direction;

    public float rotationSpeed = 345.0f;
    public float rotationSpeedOffset = 45.0f;

    public float movementSpeed = 2.0f;
    public float movementSpeedOffset = 1.0f;

    public float dissolveMultiplier = 0.5f;
    public float dissolveMultiplierOffset = 0.25f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        direction = Random.insideUnitCircle.normalized;

        rotationSpeed = Random.Range(rotationSpeed - rotationSpeedOffset, rotationSpeed + rotationSpeedOffset);
        movementSpeed = Random.Range(movementSpeed - movementSpeedOffset, movementSpeed + movementSpeedOffset);
        dissolveMultiplier = Random.Range(dissolveMultiplier - dissolveMultiplierOffset, dissolveMultiplier + dissolveMultiplierOffset);
    }

    void Update()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - Time.deltaTime * dissolveMultiplier);
        transform.position += direction * Time.deltaTime * movementSpeed;
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);
    }
}
