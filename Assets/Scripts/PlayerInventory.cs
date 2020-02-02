using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    [SerializeField] bool crowbar;
    [SerializeField] bool gasCan;
    [SerializeField] bool candle;
    [SerializeField] bool lantern;
    [SerializeField] bool sparkPlugs;
    [SerializeField] bool ductTape;
    [SerializeField] int match;

    PlayerHoldController holdController;

    void Start() {
        holdController = GetComponent<PlayerHoldController>();
        crowbar = false;
        gasCan = false;
        candle = false;
        lantern = false;
        sparkPlugs = false;
        ductTape = false;
        match = 5;
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
}
