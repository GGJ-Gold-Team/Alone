using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightSource : MonoBehaviour {
    [SerializeField] Light lightElement;
    [SerializeField] ParticleSystem particleElement;
    [SerializeField] Timer itemTimer;
    [SerializeField] bool isDepleted;
    [SerializeField] bool lightOnStart = false;

    void Start() {
        isDepleted = false;
        lightElement = GetComponentInChildren<Light>();
        particleElement = GetComponentInChildren<ParticleSystem>();
        itemTimer = GetComponent<Timer>();

        itemTimer.onTimerDepleteCallback = onDeplete;

        lightElement.enabled = lightOnStart;
        if (particleElement && !lightOnStart) {
            particleElement.Stop();
        }

        if (lightOnStart) {
            itemTimer.onTimerToggle(false);
        }
    }

    public void onToggleLightSource(bool shouldDepleteOnToggle) {
        if (!isDepleted) {
            itemTimer.onTimerToggle(shouldDepleteOnToggle);

            if (lightElement.enabled) {
                if (particleElement) {
                    particleElement.Stop();
                    particleElement.Clear();
                }
                lightElement.enabled = false;
            } else {
                if (particleElement) {
                    particleElement.Play();
                }
                lightElement.enabled = true;
            }
        }
    }

    void onDeplete() {
        lightElement.enabled = false;
        isDepleted = true;
        if (particleElement) {
            particleElement.Stop();
            particleElement.Clear();
        }
    }
}
