using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSystem : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<OxygenSystem>().Death += Dead;
    }

    void OnDisable()
    {
        GetComponent<OxygenSystem>().Death -= Dead;
    }

    private void Dead()
    {
        gameObject.SetActive(false); // Provisional para esta build
                                     // Estado de muerto, sprite/animación (futura build) ***
    }
}