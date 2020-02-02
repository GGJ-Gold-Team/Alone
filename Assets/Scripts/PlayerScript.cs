using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    [SerializeField] public bool isMenuOpen = false;


    public delegate void OnToggleMenuCallback(bool isMenuOpen);
    public OnToggleMenuCallback onToggleMenuCallback;

    void Start() {
        
    }

    void Update() {
        if (isMenuOpen && Input.GetButtonDown("Interaction")) {
            onToggleMenu(false);
        }
    }

    public void onToggleMenu(bool isOpen) {
        Debug.Log("PlayerScript: " + isOpen);
        Debug.Log("PlayerScript33: " + onToggleMenuCallback != null);

        isMenuOpen = isOpen;
        GetComponent<DeathTimer>().toggleInfinite(isOpen);
        // GetComponent<Canvas>().enabled = isOpen;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().CanMoveCamera = !isOpen;
        GetComponent<Rigidbody>().isKinematic = isOpen;
        // GetComponentInChildren<Camera>().GetComponent<Rigidbody>().isKinematic = isOpen;
        onToggleMenuCallback(isOpen);
    }
}
