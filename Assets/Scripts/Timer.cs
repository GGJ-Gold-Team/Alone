using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField] public float initialTimerValue;
    [SerializeField] public bool isTimerRunning = false;
    [SerializeField] public float currentTimerValue;
    
    public delegate void OnTimerDepleteCallback();
    public OnTimerDepleteCallback onTimerDepleteCallback;

    public delegate void OnTimerToggleCallback(bool isTimerRunning);
    public OnTimerToggleCallback onTimerToggleCallback;

    public float timerThreshold = 0;
    public bool hasThresholdTriggered = false;
    public delegate void OnTimerThresholdCallback(bool isTimerRunning);
    public OnTimerThresholdCallback onTimerThresholdCallback;

    // For debugging purposes only
    [SerializeField] bool isInfinite;

    void Start() {
        currentTimerValue = initialTimerValue;
    }

    void FixedUpdate() {
        if (!isInfinite) {
            if (isTimerRunning && currentTimerValue > 0) {
                currentTimerValue -= Time.fixedDeltaTime;
            } else if (isTimerRunning && currentTimerValue <= 0) {
                onTimerDeplete();
            }
        }

        if (currentTimerValue <= timerThreshold && !hasThresholdTriggered) {
            hasThresholdTriggered = true;
            onTimerThresholdCallback(isTimerRunning);
        }
    }

    // shouldDepleteOnToggle may be necessary for matches
    public void onTimerToggle(bool setToggleValue = false, bool newToggleValue = false, bool shouldDepleteOnToggle = false) {
        Debug.Log("timer toggled");

        if (setToggleValue) {
            if (isTimerRunning && newToggleValue == false) {
                onTimerDeplete();
            } else {
                isTimerRunning = newToggleValue;
            }
        } else {
            if (shouldDepleteOnToggle && isTimerRunning) {
                onTimerDeplete();
            } else {
                isTimerRunning = !isTimerRunning;
            }
        }

        if (onTimerToggleCallback != null) {
            onTimerToggleCallback(isTimerRunning);
        }
    }

    public void adjustTime(float timeAdjustment) {
        currentTimerValue += timeAdjustment;
    }

    public void setTime(float newTime) {
        currentTimerValue = newTime;
    }

    public void setThreshold(float newThreshold) {
        timerThreshold = newThreshold;
        if (currentTimerValue > timerThreshold) {
            hasThresholdTriggered = false;
        }
    }

    void onTimerDeplete() {
        isTimerRunning = false;
        currentTimerValue = 0; // ensures the timer gets reset correctly in case there is ever a negative value
        if (onTimerDepleteCallback != null) {
            onTimerDepleteCallback();
        }
    } 
}
