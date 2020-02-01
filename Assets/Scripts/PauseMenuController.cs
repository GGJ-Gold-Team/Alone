using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    GameController gameController;

    void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update() {
        canvas.enabled = (gameController && gameController.IsPaused);
    }
}
