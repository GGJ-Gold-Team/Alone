using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] GameObject playerCamera;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] LayerMask interactionLayerMask;
    [SerializeField] int playerReach = 4;
    GameObject interactedObject;

    void Update() {
        Interactable objectInteractable = null;
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, playerReach, interactionLayerMask)) {
            interactedObject = hit.collider.gameObject;
            objectInteractable = interactedObject.GetComponent<Interactable>();
            if (objectInteractable) {
                objectInteractable.SetHover(true);
                objectInteractable.RayPosition = hit.point;
            }
            // Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * playerReach, Color.green);
        } else {
            if (interactedObject) {
                objectInteractable = interactedObject.GetComponent<Interactable>();
                if (objectInteractable) {
                    objectInteractable.SetHover(false);
                }
            }
            interactedObject = null;
            // Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * playerReach, Color.white);
        }

        if (Input.GetButtonDown("Interaction") && objectInteractable) {
            ItemType pickedUpItem = objectInteractable.GetItemType;
            bool canPickUp = objectInteractable.CanPickUp;

            objectInteractable.OnInteraction();
            // Debug.Log(String.Format("Interacted with: {0}", pickedUpItem));

            if(canPickUp) {
            // Debug.Log(String.Format("Picked up {0}", pickedUpItem));
                playerInventory.itemUpdated(pickedUpItem);
            }
        }
    }
}
