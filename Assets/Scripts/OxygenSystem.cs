using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OxygenSystem : MonoBehaviour
{
    public static event Action Death = delegate { };
    public event Action<int> OxygenUpdated = delegate { };

    [SerializeField]
    private int maxOxygen = 200;
    [SerializeField]
    private int oxygen;
    [SerializeField]
    private int damage; // da�o por ausencia de oxigeno
    [SerializeField]
    private OxygenBar oxygenBar;

    private bool drown; // booleano para determinar cuando se est� ahogando
    private float totalTime = 0;

    private void Start()
    {
        OxygenUpdated(GetOxygen());
        drown = false;
        damage = 2; // 3 es mucho
    }

    private void Update()
    {
        ModifyOxygen(drown);
    }

    public void ModifyOxygen(bool notOxygen)
    {
        drown = notOxygen;

        if (!notOxygen)
        {
            IncrementOxygen(damage);
        }
        else if(notOxygen)
        {
            ReduceOxygen(damage);
        }        
    }

    public void ReduceOxygen(int damage)
    {
        drown = true;
        totalTime += Time.deltaTime * 2;

        if (totalTime > 1)
        {
            oxygen -= damage;

//--Oxigeno infinito--
#if __DEBUG_AVAILABLE__
            if(DebugSystem.debugMode && DebugSystem.debugInfiniteOxygen)
            {
                oxygen += damage;
            }
#endif

            if (oxygen <= 0)
            {
                oxygen = 0;
                OxygenUpdated(oxygen);
                Death();
            }
            else
            {
                OxygenUpdated(oxygen);
            }
            totalTime = 0;
        }
    }

    public void IncrementOxygen(int regen)
    {        
        oxygen += regen;

        if (oxygen >= maxOxygen)
        {
            oxygen = maxOxygen;
            OxygenUpdated(oxygen);
        }
        else
        {
            OxygenUpdated(oxygen);
        }
    }

    public int GetOxygen()
    {
        return oxygen;
    }

    public void OnEnable()
    {
        oxygen = maxOxygen;
    }
}