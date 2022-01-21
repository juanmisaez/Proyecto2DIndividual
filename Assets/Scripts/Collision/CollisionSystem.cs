using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{
    // valor X, luego cada uno lo uso para lo que lo necesite

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collider2D other)
    {
        
    }
}