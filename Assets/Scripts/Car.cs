using System;
using UnityEngine;

public class Car : Interactable {
    public void Start() {
        this.CanvasTransform = this.GetCanvas.GetComponent<RectTransform>();
        this.Player = GameObject.FindGameObjectWithTag("MainCamera");

        string header = "Things needed to repair the car:";
        string firstItem = "Gas Can";
        string secondItem = "Spark Plugs";
        // string thirdItem = "Duct Tape"; // don't have the time to finish duct tape item
        // string additionalText = System.String.Format("{0}\n{1}\n{2}\n{3}\n", header, firstItem, secondItem, thirdItem);
        string additionalText = System.String.Format("{0}\n{1}\n{2}\n", header, firstItem, secondItem);
        this.text.text = String.Format("{0}\n(Space) Interact with {1}", additionalText, StringUtils.SpaceCase(this.GetItemType.ToString()));
        RectTransform textRectTransform = this.text.GetComponent<RectTransform>();
        RectTransform imageRectTransform = this.image.GetComponent<RectTransform>();
        imageRectTransform.sizeDelta = new Vector2(this.text.preferredWidth + 10f, this.text.preferredHeight + 10f);
    }

    public void Update() {
        this.GetCanvas.enabled = this.IsHovering;

        // Follows hit location
        this.CanvasTransform.position = this.RayPosition;

        // Look at player at all times
        this.CanvasTransform.LookAt(2f * transform.position - this.Player.transform.position);
    }

    public override void OnInteraction() {
        PlayerInventory inventory = this.Player.GetComponent<PlayerInventory>();

        if (inventory.hasAllCarItems()) {
            Debug.Log("Success!");
        }
    }
}
