using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasUpdate : MonoBehaviour
{
    public static event Action<int> OxygenBarUpdate = delegate { };
    public static event Action<int> InventoryBarUpdate = delegate { };

    void OnEnable()
    {
        GetComponent<OxygenSystem>().OxygenUpdated += UpdateOxygen;
        GetComponent<InventorySystem>().InventoryUpdated += UpdateInventory;
    }

    void OnDisable()
    {
        GetComponent<OxygenSystem>().OxygenUpdated -= UpdateOxygen;
        GetComponent<InventorySystem>().InventoryUpdated -= UpdateInventory;
    }

    private void UpdateOxygen(int oxygen)
    {
        OxygenBarUpdate(oxygen);
    }

    private void UpdateInventory(int ores)
    {
        InventoryBarUpdate(ores);
    }
}