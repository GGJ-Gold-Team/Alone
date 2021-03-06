﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    GameState gameState = null;
    [SerializeField]
    GameObject[] lights;
    [SerializeField]
    GameObject playerObject;

    bool isPaused = false;

    void Start() {
        gameState = new GameState();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.GetComponent<PlayerScript>().onToggleMenuCallback = onMenuToggle;
        playerObject.GetComponent<PlayerScript>().onToggleMenu(true);
        lights = GameObject.FindGameObjectsWithTag("SafeZone");
        for (int i = 0; i < lights.Length; i++) {
            lights[i].GetComponentInChildren<FireLightSource>().toggleInfinite(true);
        }
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

    void onMenuToggle(bool isMenuOpen) {
        Debug.Log("gameController: " + isMenuOpen);
        if (!isMenuOpen) {
            for (int i = 0; i < lights.Length; i++) {
                lights[i].GetComponentInChildren<FireLightSource>().toggleInfinite(false);
                lights[i].GetComponentInChildren<FireLightSource>().onToggleLightSource(false);
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
