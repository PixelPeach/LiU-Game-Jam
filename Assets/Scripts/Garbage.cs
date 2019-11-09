using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Placeble
{
    public SpriteRenderer spriteRenderer;
    public Sprite tier2Sprite;
    public GameObject buildWindowPrefab;
    public List<GameObject> placeables = new List<GameObject>();
    public List<GameObject> tier2_placeables = new List<GameObject>();
    GameObject buildingWindow;

    private void Start()
    {
        transform.eulerAngles = StickToPlanet(transform.parent.position, transform);
    }

    void CheckForNeighbours()
    {
        GameObject[] garbageList = GameObject.FindGameObjectsWithTag("garbage");
        foreach (GameObject garbage in garbageList)
        {
            if (Vector2.Distance(transform.position, garbage.transform.position) < 1.0f)
            {
                if (garbage != gameObject)
                {
                    //TODO: change placeables to tier 2 and change the current sprite to tier 2
                    spriteRenderer.sprite = tier2Sprite;
                    placeables = tier2_placeables;
                    //Instantiate(tier2, transform.position, Quaternion.identity, transform.parent);
                    //Destroy(buildingWindow);      
                    Destroy(garbage);
                }
            }
        }
    }

    /// <summary>
    /// Might need to make a own onmouse enter function
    /// </summary>
    private void OnMouseEnter()
    {
        CheckForNeighbours();
        buildingWindow = Instantiate(buildWindowPrefab, transform.position, Quaternion.identity);
        buildingWindow.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        buildingWindow.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseOver()
    {
        if (true) //Building phase
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                Debug.Log("Tower");
                Instantiate(placeables[0], transform.position, Quaternion.identity, transform.parent);
                Destroy(this.gameObject);
                Destroy(buildingWindow);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                Instantiate(placeables[1], transform.position, Quaternion.identity, transform.parent);
                Destroy(this.gameObject);
                Destroy(buildingWindow);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                Instantiate(placeables[2], transform.position, Quaternion.identity, transform.parent);
                Destroy(this.gameObject);
                Destroy(buildingWindow);
            }
        }
    }

    private void OnMouseExit()
    {
        Destroy(buildingWindow);
    }

}
