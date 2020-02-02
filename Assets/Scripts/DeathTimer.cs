using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour {
    [SerializeField] float initialTime;
    [SerializeField] float currentTime;
    [SerializeField] bool isTimerRunning;
    [SerializeField] public float timerSafetyBuffer;
    [SerializeField] Timer deathTimer;

    void Start() {
        deathTimer = GetComponent<Timer>();
        deathTimer.setTime(initialTime);
        deathTimer.isTimerRunning = true;
        deathTimer.onTimerThresholdCallback = onThresholdHit;
        deathTimer.onTimerDepleteCallback = onDeath;
    }

    public void enterSafeZone(float safeZoneBuffer) {
        timerSafetyBuffer += safeZoneBuffer;
        deathTimer.setThreshold(timerSafetyBuffer);

        if (deathTimer.currentTimerValue < safeZoneBuffer) {
            deathTimer.onTimerToggle(true, false);
            deathTimer.setTime(safeZoneBuffer);
        }
    }
    
    public void leaveSafeZone(float safeZoneBuffer) {
        timerSafetyBuffer -= safeZoneBuffer;
        deathTimer.setThreshold(timerSafetyBuffer);

        if (timerSafetyBuffer < deathTimer.currentTimerValue) {
            deathTimer.onTimerToggle(true, true);
        }
    }

    void onThresholdHit(bool isTimerRunning) {
        deathTimer.onTimerToggle(true, false);
        deathTimer.setTime(timerSafetyBuffer);
    }

    void onDeath() {
        Debug.Log("You are Dead");
    }
}