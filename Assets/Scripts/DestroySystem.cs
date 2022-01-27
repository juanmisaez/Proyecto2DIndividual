using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySystem : MonoBehaviour
{
    private void Dead()
    {
        FindObjectOfType<AudioManager>().Play("Ore");
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        GetComponent<HealthSystem>().Death += Dead;
    }

    void OnDisable()
    {
        GetComponent<HealthSystem>().Death += Dead;
    }
}