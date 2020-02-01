using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    private GameObject playerCamera;
    GameObject interactedObject;
    [SerializeField] int playerReach = 4;
    [SerializeField] LayerMask layerMask;

    void Start() {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, playerReach, layerMask)) {
            interactedObject = hit.collider.gameObject;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * playerReach, Color.green);
        } else {
            interactedObject = null;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * playerReach, Color.white);
        }
    }
}
