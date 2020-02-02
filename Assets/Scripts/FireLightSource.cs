using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightSource : MonoBehaviour {
    [SerializeField] Light lightElement;
    [SerializeField] ParticleSystem particleElement;
    [SerializeField] Timer itemTimer;
    [SerializeField] bool isDepleted;

    void Start() {
        isDepleted = false;
        lightElement = GetComponentInChildren<Light>();
        particleElement = GetComponentInChildren<ParticleSystem>();
        itemTimer = GetComponent<Timer>();

        itemTimer.onTimerDepleteCallback = onDeplete;

        lightElement.enabled = false;
        particleElement.Stop();
    }

    public void onToggleLightSource(bool shouldDepleteOnToggle) {
        if (!isDepleted) {
            itemTimer.onTimerToggle(shouldDepleteOnToggle);

            if (lightElement.enabled) {
                particleElement.Stop();
                particleElement.Clear();
                lightElement.enabled = false;
            } else {
                particleElement.Play();
                lightElement.enabled = true;
            }
        }
    }

    void onDeplete() {
        lightElement.enabled = false;
        isDepleted = true;
        particleElement.Stop();
        particleElement.Clear();
    }
}
