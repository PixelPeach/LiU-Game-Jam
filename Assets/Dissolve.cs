using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Vector3 direction;

    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * 2.5f;
        transform.Rotate(0, 0, -345.0f * Time.deltaTime, Space.Self);
    }
}
