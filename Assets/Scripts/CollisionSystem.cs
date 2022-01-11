using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{    
    //lo que sea con lo que sea
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collider2D other)
    {

    }
}