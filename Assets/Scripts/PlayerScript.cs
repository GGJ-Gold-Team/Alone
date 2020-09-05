using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public delegate void OnToggleMenuCallback(bool isMenuOpen);
    public OnToggleMenuCallback onToggleMenuCallback;

    bool isMenuOpen = false;

    void Update() {
        if (isMenuOpen && Input.GetButtonDown("Interaction")) {
            onToggleMenu();
        }
    }

    public void onToggleMenu() {
        isMenuOpen = !isMenuOpen;
        DeathTimer.Instance.toggleInfinite(isMenuOpen);
        DeathTimer.Instance.toggleInfinite(isMenuOpen);
        // GetComponent<Canvas>().enabled = isMenuOpen;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().CanMoveCamera = !isMenuOpen;
        GetComponent<Rigidbody>().isKinematic = isMenuOpen;
        // GetComponentInChildren<Camera>().GetComponent<Rigidbody>().isKinematic = isMenuOpen;
        onToggleMenuCallback(isMenuOpen);
    }
}
