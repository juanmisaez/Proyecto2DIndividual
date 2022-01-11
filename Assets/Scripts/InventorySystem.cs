using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventorySystem : MonoBehaviour
{
    public event Action<int> InventoryUpdated = delegate { };

    [SerializeField]
    private int maxOres = 3;
    [SerializeField]
    private int ores;
    [SerializeField]
    private OxygenBar inventoryBar;

    private int oresStart = 0;

    void Start()
    {
        InventoryUpdated(GetOres());
    }

    public int GetOres()
    {
        return ores;
    }

    public void OnEnable()
    {
        ores = oresStart;
    }
}