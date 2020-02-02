using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightSource : MonoBehaviour {
    [SerializeField] Light lightElement;
    [SerializeField] ParticleSystem particleElement;
    [SerializeField] Timer itemTimer;
    [SerializeField] Collider safeZone;
    [SerializeField] bool isDepleted;
    [SerializeField] bool lightOnStart = false;
    [SerializeField] bool isPlayerTriggered = false;

    [SerializeField] DeathTimer deathTimer;
    [SerializeField] float safetyThreshold;

    void Start() {
        isDepleted = false;
        lightElement = GetComponentInChildren<Light>();
        particleElement = GetComponentInChildren<ParticleSystem>();
        itemTimer = GetComponent<Timer>();
        safeZone = GetComponent<Collider>();
        deathTimer = GameObject.FindGameObjectWithTag("Player").GetComponent<DeathTimer>();

        // Debug.Log(System.String.Format("safetyThreshold onStart: {0}", safetyThreshold));

        itemTimer.onTimerDepleteCallback = onDeplete;

        lightElement.enabled = lightOnStart;
        safeZone.enabled = lightOnStart;
        if (particleElement && !lightOnStart) {
            particleElement.Stop();
        }

        if (lightOnStart) {
            itemTimer.onTimerToggle(false);
        }
    }

    public void onToggleLightSource(bool shouldDepleteOnToggle) {
        if (!isDepleted) {
            itemTimer.onTimerToggle(shouldDepleteOnToggle: shouldDepleteOnToggle);

            if (lightElement.enabled) {
                if (particleElement) {
                    particleElement.Stop();
                    particleElement.Clear();
                }
                lightElement.enabled = false;
                safeZone.enabled = false;
                deathTimer.leaveSafeZone(safetyThreshold);
                isPlayerTriggered = false;
            } else {
                if (particleElement) {
                    particleElement.Play();
                }
                lightElement.enabled = true;
                safeZone.enabled = true;
            }
        }
    }

    void onDeplete() {
        lightElement.enabled = false;
        isDepleted = true;
        if (isPlayerTriggered) {
            isPlayerTriggered = false;
            deathTimer.leaveSafeZone(safetyThreshold);
        }

        if (particleElement) {
            particleElement.Stop();
            particleElement.Clear();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            deathTimer.enterSafeZone(safetyThreshold);
            isPlayerTriggered = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            deathTimer.leaveSafeZone(safetyThreshold);
            isPlayerTriggered = false;
        }
    }
}
