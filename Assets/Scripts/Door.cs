using UnityEngine;

public class Door : Interactable {

    [SerializeField] Animator animator;

    bool isOpen = false;

    public override void OnInteraction() {
        base.OnInteraction();
        isOpen = !isOpen;
        animator.SetTrigger("OpenDoor");
    }
}