using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placeble : MonoBehaviour
{
    protected float angle;

    protected Vector3 StickToPlanet(Vector2 parent, Transform self)
    {
        float deltaX = parent.x - self.position.x;
        float deltaY = parent.y - self.position.y;
        angle = Mathf.Atan2(deltaY, deltaX);
        return new Vector3(self.rotation.x, self.rotation.y, (Mathf.Rad2Deg * angle) + (Mathf.Rad2Deg * (Mathf.PI / 2)));
    }

}
