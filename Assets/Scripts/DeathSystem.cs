using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSystem : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<OxygenSystem>().Death += Dead;
    }

    void OnDisable()
    {
        GetComponent<OxygenSystem>().Death -= Dead;
    }

    private void Dead()
    {
        gameObject.SetActive(false); // Provisional para esta build
                                     // Estado de muerto, sprite/animación (futura build) ***
    }


    // destruir bloques en una clase hijo

    /*IEnumerator DestroyBlock(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(blockDestroyTime);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);

        destroyingBlock = false;
    }*/
}