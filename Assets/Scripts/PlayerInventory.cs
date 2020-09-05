using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventory : MonoBehaviour {
    [SerializeField] bool candle;
    [SerializeField] bool crowbar;
    [SerializeField] bool ductTape;
    [SerializeField] bool gasCan;
    [SerializeField] bool lantern;
    [SerializeField] int match;
    [SerializeField] bool sparkPlugs;

    PlayerHoldController holdController;

    void Start() {
        holdController = GetComponent<PlayerHoldController>();
        candle = false;
        crowbar = false;
        ductTape = false;
        gasCan = false;
        lantern = false;
        match = 5;
        sparkPlugs = false;
    }

    public void itemUpdated(ItemType item) {
        if (item == ItemType.Crowbar) {
            this.crowbar = true;
        } else if (item == ItemType.GasCan) {
            this.gasCan = true;
        } else if (item == ItemType.Candle) {
            this.candle = true;
        } else if (item == ItemType.Lantern) {
            this.lantern = true;
        } else if (item == ItemType.SparkPlugs) {
            this.sparkPlugs = true;
        } else if (item == ItemType.DuctTape) {
            this.ductTape = true;
        } else if (item == ItemType.Match) {
            this.match++;
        }

        holdController.EquipItem(item);
    }

    public bool hasAllCarItems() {
        return gasCan && sparkPlugs;
    }

    public override string ToString() {
        string stringified = "{";

        stringified += string.Format("\n  candle: {0}", candle);
        stringified += string.Format("\n  crowbar: {0}", crowbar);
        stringified += string.Format("\n  ductTape: {0}", ductTape);
        stringified += string.Format("\n  gasCan: {0}", gasCan);
        stringified += string.Format("\n  lantern: {0}", lantern);
        stringified += string.Format("\n  match: {0}", match);
        stringified += string.Format("\n  sparkPlugs: {0}\n", sparkPlugs);

        stringified += "}";
        return stringified;
    }
}
