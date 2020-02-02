using System;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Image image;

    [SerializeField] Canvas canvas;
    [SerializeField] ItemType itemType;
    [SerializeField] bool canPickUp = false;
    [SerializeField] bool shouldDestroyOnPickup = false;

    [HideInInspector] Vector3 rayPosition;
    [HideInInspector] RectTransform canvasTransform;
    [HideInInspector] bool isHovering = false;
    [HideInInspector] GameObject player;

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
        canvasTransform.LookAt(2f * transform.position - player.transform.position);
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
        get {
            return rayPosition;
        }

        set {
            rayPosition = value;
        }
    }

    public Canvas GetCanvas {
        get {
            return canvas;
        }

        set {
            canvas = value;
        }
    }

    public RectTransform CanvasTransform {
        get {
            return canvasTransform;
        }

        set {
            canvasTransform = value;
        }
    }

    public GameObject Player {
        get {
            return player;
        }

        set {
            player = value;
        }
    }

    public virtual void OnInteraction() {
        if (itemType == ItemType.Candle) {
            FireLightSource candleLight = GetComponentInChildren<FireLightSource>();
            candleLight.onToggleLightSource(false);
        }

        if (shouldDestroyOnPickup) {
            Destroy(this.gameObject);
        }
    }
}

public enum ItemType {
    Candle,
    Car,
    Crowbar,
    Door,
    DuctTape,
    Fireplace,
    GasCan,
    Key,
    Lantern,
    Match,
    SparkPlugs
}
