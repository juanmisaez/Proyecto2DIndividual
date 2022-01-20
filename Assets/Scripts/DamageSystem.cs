using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// TESTING

public class DamageSystem : MonoBehaviour
{
    public event Action<int> UpdateDamage = delegate { };

    [SerializeField]
    private int minDamage;
    [SerializeField]
    private int damage;

    private void Start()
    {
        UpdateDamage(GetDamage());
    }

    public int GetDamage()
    {
        return damage;
    }

    public void OnEnable()
    {
        damage = minDamage;
    }
}
