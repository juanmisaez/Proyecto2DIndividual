using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionDamage : CollisionSystem
{
    [SerializeField]
    private int damage; // si la tiene el padre, no haría falta

    protected override void OnCollision(Collider2D other)
    {
        other.gameObject.GetComponent<HealthSystem>()?.ReduceHealth(damage);
    }
}