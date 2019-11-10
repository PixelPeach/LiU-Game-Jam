using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandeler : MonoBehaviour
{
    void RestartGame() {
        SceneManager.LoadScene(0);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RestartGame();
        }
    }
}
