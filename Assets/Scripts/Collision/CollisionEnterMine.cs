using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionEnterMine : CollisionSystem
{    
    [SerializeField]
    private bool notOxygen;

    protected override void OnCollision(Collider2D other)
    {        
        other.gameObject.GetComponent<OxygenSystem>()?.ModifyOxygen(notOxygen);
    }
}