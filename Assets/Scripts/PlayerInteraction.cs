using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    GameObject playerCamera;
    [SerializeField] GameObject interactedObject;
    [SerializeField] int playerReach = 4;
    [SerializeField] LayerMask interactionLayerMask;
    [SerializeField] PlayerInventory playerInventory;

    void Start() {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerInventory = GetComponent<PlayerInventory>();
    }

    void Update() {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, playerReach, interactionLayerMask)) {
            interactedObject = hit.collider.gameObject;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * playerReach, Color.green);
        } else {
            interactedObject = null;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * playerReach, Color.white);
        }

        if (Input.GetButtonDown("Interaction") && interactedObject != null) {
            bool canPickUp = true;
            string pickedUpItem = "crowbar";

            if(canPickUp) {
                playerInventory.itemUpdated(pickedUpItem);
            }
        }
    }
}
