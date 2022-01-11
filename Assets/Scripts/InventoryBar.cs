using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryBar : MonoBehaviour
{
    public Slider slider;

    void OnEnable()
    {
        CanvasUpdate.InventoryBarUpdate += SetInventory; 
    }

    void OnDisable()
    {
        CanvasUpdate.InventoryBarUpdate -= SetInventory;  
    }

    public void SetMaxIventory(int ores) 
    {
        slider.maxValue = ores; 
        slider.value = ores; 
    }

    public void SetInventory(int ores) 
    {
        slider.value = ores;
    }
}