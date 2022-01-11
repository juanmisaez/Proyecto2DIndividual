using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OxygenBar : MonoBehaviour
{
    public Slider slider;

    void OnEnable()
    {
        CanvasUpdate.OxygenBarUpdate += SetOxygen;
    }

    void OnDisable()
    {
        CanvasUpdate.OxygenBarUpdate -= SetOxygen;
    }

    public void SetMaxOxygen(int oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
    }

    public void SetOxygen(int oxygen)
    {
        slider.value = oxygen;
    }
}