using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    private void Dead()
    {
        gameObject.SetActive(false); // Provisional para esta build
                                     // Estado de muerto, sprite/animación (futura build) ***
    }

    void OnEnable()
    {
        OxygenSystem.Death += Dead;
    }

    void OnDisable()
    {
        OxygenSystem.Death -= Dead;
    }
}