using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField] float initialTimerValue;
    [SerializeField] public bool isTimerRunning;
    [SerializeField] public float currentTimerValue;
    
    public delegate void OnTimerDepleteCallback();
    public OnTimerDepleteCallback onTimerDepleteCallback;

    // For debugging purposes only
    [SerializeField] bool isInfinite;

    void Start() {
        isTimerRunning = false;
        currentTimerValue = initialTimerValue;
    }

    void FixedUpdate() {
        if(!isInfinite) {
            if (isTimerRunning && currentTimerValue > 0) {
                currentTimerValue -= Time.fixedDeltaTime;
            } else if (isTimerRunning && currentTimerValue <= 0) {
                onTimerDeplete();
            }
        }
    }

    // shouldDepleteOnToggle may be necessary for matches
    public void onTimerToggle(bool shouldDepleteOnToggle) {
        Debug.Log("timer toggled");
        if (shouldDepleteOnToggle && isTimerRunning) {
            onTimerDeplete();
        } else {
            isTimerRunning = !isTimerRunning;
        }
    }

    void onTimerDeplete() {
        isTimerRunning = false;
        currentTimerValue = 0; // ensures the timer gets reset correctly in case there is ever a negative value
        if(onTimerDepleteCallback != null) {
            onTimerDepleteCallback();
        }
    } 
}
