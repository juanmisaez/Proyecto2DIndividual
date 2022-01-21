using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionOre : CollisionSystem
{
    [SerializeField]
    private int nugget = 1; // si la tiene el padre, no har�a falta

    protected override void OnCollision(Collider2D other)
    {        
        other.gameObject.GetComponent<InventorySystem>()?.IncrementOre(nugget);
    }
}