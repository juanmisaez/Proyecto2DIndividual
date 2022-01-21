using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionDamage : CollisionSystem
{
    [SerializeField]
    private int damage; // si la tiene el padre, no har�a falta

    protected override void OnCollision(Collider2D other)
    {
        other.gameObject.GetComponent<HealthSystem>()?.ReduceHealth(damage);
    }
}