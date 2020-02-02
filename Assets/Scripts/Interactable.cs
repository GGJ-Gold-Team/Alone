using System;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [SerializeField] Canvas canvas;
    [SerializeField] UnityEngine.UI.Text text;
    [SerializeField] UnityEngine.UI.Image image;
    [SerializeField] ItemType itemType;
    [SerializeField] bool canPickUp = false;

    Vector3 rayPosition;
    RectTransform canvasTransform;
    bool isHovering = false;
    GameObject player;

    public void Start() {
        canvasTransform = canvas.GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        text.text = String.Format("(Space) Interact with {0}", StringUtils.SpaceCase(itemType.ToString()));
        RectTransform textRectTransform = text.GetComponent<RectTransform>();
        RectTransform imageRectTransform = image.GetComponent<RectTransform>();
        imageRectTransform.sizeDelta = new Vector2(text.preferredWidth + 10f, imageRectTransform.rect.height);
    }

    public void Update() {
        canvas.enabled = isHovering;

        // Follows hit location
        canvasTransform.position = rayPosition;

        // Look at player at all times
        canvasTransform.LookAt(transform.position - player.transform.position);
    }

    public void SetHover(bool newIsHovering) {
        isHovering = newIsHovering;
    }

    public ItemType GetItemType {
        get {
            return itemType;
        }
    }

    public bool IsHovering {
        get {
            return isHovering;
        }
    }

    public bool CanPickUp {
        get {
            return canPickUp;
        }
    }

    public Vector3 RayPosition {
        set {
            rayPosition = value;
        }
    }

    public virtual void OnInteraction() {
        Timer itemTimer = GetComponent<Timer>();
        if (itemTimer && itemType == ItemType.Candle) {
            itemTimer.onTimerToggle(false);
        }
    }
}

public enum ItemType {
    Candle,
    Crowbar,
    Door,
    DuctTape,
    Fireplace,
    GasCan,
    Lantern,
    Match,
    SparkPlugs
}
