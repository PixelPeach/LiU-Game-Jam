using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundHandeler : MonoBehaviour
{
    public Button startRound;
    public Button nextRound;

    void Update()
    {
        if (GameObject.Find("truck") != null) {
            startRound.interactable = false;
            nextRound.interactable = false;
        }
        else {
            startRound.interactable = true;
            nextRound.interactable = true;
        }
    }
}
