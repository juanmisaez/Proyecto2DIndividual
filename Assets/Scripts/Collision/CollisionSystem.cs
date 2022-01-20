using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{
    [SerializeField]
    private int damage;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collider2D other)
    {
        other.gameObject.GetComponent<HealthSystem>()?.ReduceHealth(damage);
    }
}