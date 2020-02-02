using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldController : MonoBehaviour {
    [SerializeField] GameObject crowbarPrefab, gasCanPrefab, candlePrefab, lanternPrefab, sparkPlugsPrefab, ductTapePrefab, matchPrefab;

    GameObject heldItem;

    public void EquipItem(ItemType itemToEquip) {
        if (heldItem) {
            UnequipItem();
        }

        GameObject itemToEquipPrefab = GetItemForType(itemToEquip);

        if (itemToEquipPrefab) {
            Vector3 itemRelativeLocation = new Vector3(-0.25f, 0.25f, 0.65f);
            GameObject item = GameObject.Instantiate(itemToEquipPrefab);
            item.transform.SetParent(transform);
            item.transform.localPosition = itemRelativeLocation;
            item.GetComponent<Collider>().enabled = false;
            heldItem = itemToEquipPrefab;
        }
    }

    public void UnequipItem() {
        if (heldItem) {
            Destroy(heldItem);
            heldItem = null;
        }
    }

    GameObject GetItemForType(ItemType item) {
        switch (item) {
            case ItemType.Crowbar:
                return crowbarPrefab;
            case ItemType.GasCan:
                return gasCanPrefab;
            case ItemType.Candle:
                return candlePrefab;
            case ItemType.Lantern:
                return lanternPrefab;
            case ItemType.SparkPlugs:
                return sparkPlugsPrefab;
            case ItemType.DuctTape:
                return ductTapePrefab;
            case ItemType.Match:
                return matchPrefab;
            default:
                return null;
        }
    }
}
