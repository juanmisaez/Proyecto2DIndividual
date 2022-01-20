using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// TESTING

public class HealthBlockSystem : MonoBehaviour
{
    public event Action Death = delegate { };
    public event Action<int> LifeUpdated = delegate { };

    private BreakBlockSystem _breakBlockSystem;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

    private void Awake()
    {
        _breakBlockSystem = GetComponent<BreakBlockSystem>();
    }

    private void Start()
    {
        LifeUpdated(GetHealth());
    }

    public void ReduceHealth()//int damage)
    {
        health -= _breakBlockSystem.damagePickaxe;//damage;

        Debug.Log("el bloque ha perdido " + _breakBlockSystem.damagePickaxe + " de " + maxHealth);

        if (health <= 0)
        {
            health = 0;
            LifeUpdated(health); // es necesario notificar la vida porque Death destruye el objeto y podría no dar tiempo a que el canvas se actualice.
            Death();
        }
        else
        {
            LifeUpdated(health);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void OnEnable()
    {
        health = maxHealth;
        //GetComponent<BreakBlockSystem>().DamageUpdated += ReduceHealth;
    }
    /*void OnDisable()
    {
        GetComponent<BreakBlockSystem>().DamageUpdated -= ReduceHealth;
    }*/
}