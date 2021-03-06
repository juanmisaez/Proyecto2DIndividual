using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public event Action Death = delegate { };
    public event Action<int> LifeUpdated = delegate { };

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

    private void Start()
    {
        LifeUpdated(GetHealth());
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            LifeUpdated(health); // es necesario notificar la vida porque Death destruye el objeto y podr?a no dar tiempo a que el canvas se actualice.
            Death();
        }
        else
        {
            LifeUpdated(health);
        }
    }

    public void OnEnable()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }
}