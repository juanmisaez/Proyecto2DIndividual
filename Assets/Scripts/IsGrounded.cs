using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IsGrounded : MonoBehaviour
{
    public event Action<bool, bool> Ground = delegate { };

    public float skinWidth = 0.1f; // Tamañano del cast
    const int layerGround = 7; // Numero de layer
    const int layerStructure = 8; // Numero de layer
    CapsuleCollider2D _capsule;

    public bool onGrounded;
    public bool layer1;
    public bool layer2;

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        Vector2 position = (Vector2)transform.position + _capsule.offset;
        layer1 = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, -Vector2.up, skinWidth, (1 << layerGround));
        layer2 = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, -Vector2.up, skinWidth, (1 << layerStructure));

        Ground(layer1, layer2);
        //Debug.Log("Detecta tierra Bola es: " + onGrounded);
    }
}