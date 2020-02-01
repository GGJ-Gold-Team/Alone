using System;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [SerializeField] Canvas canvas;
    [SerializeField] UnityEngine.UI.Text text;
    [SerializeField] UnityEngine.UI.Image image;

    RectTransform canvasTransform;
    bool isHovering = false;
    GameObject player;

    void Start() {
        canvasTransform = canvas.GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        text.text = String.Format("(space) Interact with {0}", this.gameObject.name);
        RectTransform textRectTransform = text.GetComponent<RectTransform>();
        RectTransform imageRectTransform = image.GetComponent<RectTransform>();
        imageRectTransform.sizeDelta = new Vector2(text.preferredWidth + 10f, imageRectTransform.rect.height);
    }

    void Update() {
        canvas.enabled = isHovering;

        // Static position regardless of parent rotation
        canvasTransform.position = transform.position + new Vector3(0, 0.5f);

        // Look at player at all times
        canvasTransform.LookAt(2f * transform.position - player.transform.position);
    }

    public void SetHover(bool newIsHovering) {
        isHovering = newIsHovering;
    }
}