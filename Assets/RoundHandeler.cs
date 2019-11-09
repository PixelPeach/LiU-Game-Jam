using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundHandeler : MonoBehaviour
{
    public Button startRound;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("truck") != null) {
            startRound.interactable = false;
        }
        else {
            startRound.interactable = true;
        }
    }
}
