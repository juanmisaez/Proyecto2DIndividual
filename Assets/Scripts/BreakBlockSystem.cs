using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class BreakBlockSystem : MonoBehaviour
{
    //public event Action<int> DamageUpdated = delegate { };

    public Tilemap[] groundTileMap;

    public float casDistance = 1.0f;
    public Transform raycastPoint;
    public LayerMask layer;

    public float blockDestroyTime = 1f;

    Vector3 direction;
    RaycastHit2D hit;

    bool destroyingBlock = false;
    public int damagePickaxe; // Sin uso por el momento
    int levelPickaxe;

    private InputSystemKeyboard _inputSystemKeyboard;

    private void Awake()
    {
        _inputSystemKeyboard = GetComponent<InputSystemKeyboard>();
    }

    private void Update()
    {
        if (_inputSystemKeyboard.hor != 0 || _inputSystemKeyboard.ver == -1)
        {
            direction.x = _inputSystemKeyboard.hor;
            direction.y = _inputSystemKeyboard.ver;
        }
    }

    void RaycastDirection()
    {
        hit = Physics2D.Raycast(raycastPoint.position, direction, casDistance, layer.value);
        
        Vector2 endpos = raycastPoint.position + direction;

        Debug.DrawLine(raycastPoint.position, endpos, Color.red); 

        if(_inputSystemKeyboard.space)
        {
            if(hit.collider && !destroyingBlock)
            {
                //---
                // Al HealthSystem
                //DamageUpdated(damagePickaxe);
                //---

                destroyingBlock = true;
                StartCoroutine(DestroyBlock(hit.collider.gameObject.GetComponent<Tilemap>(), endpos));
            }
        }    
    }

    //******************* Al Deathsystem ************************
    IEnumerator DestroyBlock(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(blockDestroyTime);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);
        
        TileBase t = map.GetTile(new Vector3Int((int)pos.x, (int)pos.y,0));

        //Debug.Log("nombre " + t.name);

        if(t.name == "Terreno_2") // el marrón
        {
            map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
        }
        if (t.name == "Terreno_4" && levelPickaxe >= 2) // el azul
        {
            map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
        }
        if (t.name == "Terreno_7" && levelPickaxe == 3) // el metálico
        {
            map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
        }

        destroyingBlock = false;
    }
    //***********************************************************

    void LevelPickaxe(int nv)
    {
        // nv == 2 o 3
        levelPickaxe = nv;
    }

    void DamagePickaxe(int damage) // Sin uso por el momento
    {
        damagePickaxe = damage;
    }

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().Dig += RaycastDirection;
        GetComponent<DamageSystem>().UpdateDamage += DamagePickaxe; // Sin uso por el momento
        ScriptSystem.UpgradePickaxe += LevelPickaxe;
    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().Dig -= RaycastDirection;
        GetComponent<DamageSystem>().UpdateDamage -= DamagePickaxe; // Sin uso por el momento
        ScriptSystem.UpgradePickaxe += LevelPickaxe;
    }
}