using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionOre : CollisionSystem
{
    [SerializeField]
    private int nugget = 1;

    protected override void OnCollision(Collider2D other)
    {        
        other.gameObject.GetComponent<InventorySystem>()?.IncrementOre(nugget);
    }
}