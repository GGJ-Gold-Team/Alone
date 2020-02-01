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

    void Start() {
        crowbar = false;
        gasCan = false;
        candle = false;
        lantern = false;
        sparkPlugs = false;
        ductTape = false;
        match = 5;
    }

    public void itemUpdated(string item) {
        if (item == "crowbar") {
            this.crowbar = true;
        } else if (item == "gasCan") {
            this.gasCan = true;
        } else if (item == "candle") {
            this.candle = true;
        } else if (item == "lantern") {
            this.lantern = true;
        } else if (item == "sparkPlugs") {
            this.sparkPlugs = true;
        } else if (item == "ductTape") {
            this.ductTape = true;
        } else if (item == "match") {
            this.match++;
        }
    }
}
