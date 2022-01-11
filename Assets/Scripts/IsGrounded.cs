using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IsGrounded : MonoBehaviour
{
    //public event Action<bool> Ground = delegate { };

    //------------------CHEMA------------------

    public float skinWidth = 0.1f;
    const int layerGround = 7;
    CapsuleCollider2D _capsule;

    public bool isGrounded;

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        Vector2 position = (Vector2)transform.position + _capsule.offset;
        isGrounded = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, -Vector2.up, skinWidth, (1 << layerGround));

    //------------------CHEMA------------------
            
        /*Ground(isGrounded);
        Debug.Log("Detecta tierra Bola es: " + isGrounded);*/
    }
}