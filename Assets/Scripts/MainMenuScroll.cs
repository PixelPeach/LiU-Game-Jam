using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScroll : MonoBehaviour
{
    float width = 20;

    void Update()
    {
        if (width > 200) {
            width = 20;
        }

        width += Time.deltaTime;
        GetComponent<SpriteRenderer>().size = new Vector2(width, width);
    }
}
