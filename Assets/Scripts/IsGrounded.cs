using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IsGrounded : MonoBehaviour
{
    public event Action<bool, bool> Ground = delegate { };
    public event Action<bool, bool> Roof = delegate { };

    public float skinWidth = 0.1f; // Tamañano del cast
    const int layerGround = 7; // Numero de layer
    const int layerStructure = 8; // Numero de layer
    CapsuleCollider2D _capsule;

    public bool onGrounded;
    public bool floor1;
    public bool floor2;

    public bool roof1; //---TEST---
    public bool roof2; //---TEST---

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        Vector2 position = (Vector2)transform.position + _capsule.offset;
        floor1 = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, -Vector2.up, skinWidth, (1 << layerGround));
        floor2 = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, -Vector2.up, skinWidth, (1 << layerStructure));

        Ground(floor1, floor2);

        //---TEST---
        roof1 = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, Vector2.up, skinWidth, (1 << layerGround));
        roof2 = Physics2D.CapsuleCast(position, _capsule.size, _capsule.direction, 0, Vector2.up, skinWidth, (1 << layerStructure));
        Roof(roof1, roof2);
        //---TEST---
    }
}