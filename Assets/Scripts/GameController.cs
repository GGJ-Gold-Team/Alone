using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    GameState gameState = null;

    bool isPaused = false;

    void Start() {
        gameState = new GameState();
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (isPaused) {
                Unpause();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Unpause() {
        isPaused = false;
        Time.timeScale = 1;
    }

    public bool IsPaused {
        get {
            return isPaused;
        }
    }
}
