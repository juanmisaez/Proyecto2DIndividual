using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class RopeSystem : MonoBehaviour
{
    public Tilemap[] groundTileMap;

    public float casDistance = 1.0f;
    public Transform raycastPoint;
    public LayerMask layerForRope;
    public LayerMask layerForHook;

    public float timerTest = 0f;

    Vector3 direction;
    RaycastHit2D ropeRaycast;
    RaycastHit2D hookRaycast;

    bool solidBlock = false;

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
        Vector2 rope = raycastPoint.position + direction * 2;   // distancia de 3 tiles, valor a modificar para aumentar la cuerda
        Vector2 hook;
        hook.x = rope.x + direction.x;
        hook.y = rope.y + direction.y;

        ropeRaycast = Physics2D.Raycast(raycastPoint.position, direction, casDistance, layerForRope.value);
        hookRaycast = Physics2D.Raycast(hook, direction, casDistance, layerForHook.value);

        Debug.DrawLine(raycastPoint.position, rope, Color.green); // la cuerda
        Debug.DrawLine(rope, hook, Color.cyan);                   // gancho        

        int ropeLenght = 1; //---

        //Debug.DrawLine(raycastPoint.position, endpos, Color.red);

        if (_inputSystemKeyboard.space)
        {
            if (ropeRaycast.collider && !solidBlock)
            {
                solidBlock = true;
                StartCoroutine(DestroyBlock(ropeRaycast.collider.gameObject.GetComponent<Tilemap>(), rope, ropeLenght));
            }
        }
    }

    IEnumerator DestroyBlock(Tilemap map, Vector2 pos, int _ropeLenght) // añadir variable int: longitud de la cuerda
    {
        yield return new WaitForSeconds(timerTest);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        TileBase tile = map.GetTile(new Vector3Int((int)pos.x, (int)pos.y, 0));
      
        for(int t = 1; t < _ropeLenght; t++)
        {
            Vector2 rope = raycastPoint.position + direction * t;

            if (tile.name == "Terreno_0") // fondo
            {
                Debug.Log("¡Todo despejado!");
                // dar permiso para ejecutar la siguiente corrutina
            }
        }
        

        if (tile.name == "Terreno_1" || tile.name == "Terreno_4" || tile.name == "Terreno_5" || tile.name == "Terreno_6") // estructura // el marrón // el azul // el metálico
        {
            Debug.Log("¡Enganchao'!");
            // evento al Engine.cs para que suba 
        }

        solidBlock = false;
    }

    /*
    void RaycastDirection()
    {              
        Vector2 rope = raycastPoint.position + direction * 2;   // distancia de 3 tiles, valor a modificar para aumentar la cuerda
        Vector2 hook;
        hook.x = rope.x + direction.x;
        hook.y = rope.y + direction.y;

        ropeRaycast = Physics2D.Raycast(raycastPoint.position, direction, casDistance, layerForRope.value);
        hookRaycast = Physics2D.Raycast(hook, direction, casDistance, layerForHook.value);

        Debug.DrawLine(raycastPoint.position, rope, Color.green); // la cuerda
        Debug.DrawLine(rope, hook, Color.cyan);                   // gancho

        if (_inputSystemKeyboard.w)
        {
            if (ropeRaycast.collider && !solidBlock)
            {
                solidBlock = true;
                StartCoroutine(CheckBlockRope(ropeRaycast.collider.gameObject.GetComponent<Tilemap>(), rope));

                if(hookRaycast.collider && !solidBlock)
                {
                    StartCoroutine(CheckBlockHook(hookRaycast.collider.gameObject.GetComponent<Tilemap>(), hook));
                }                
            }
        }
    }
    
    IEnumerator CheckBlockRope(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(timerTest);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        TileBase t = map.GetTile(new Vector3Int((int)pos.x, (int)pos.y, 0));

        if(t.name == "Terreno_0") // fondo
        {
            Debug.Log("¡Todo despejado!");
            // dar permiso para ejecutar la siguiente corrutina
        }

        solidBlock = false;
    }

    IEnumerator CheckBlockHook(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(timerTest);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        TileBase t = map.GetTile(new Vector3Int((int)pos.x, (int)pos.y, 0));

        if(t.name == "Terreno_1" || t.name == "Terreno_4" || t.name == "Terreno_5" || t.name == "Terreno_6") // estructura // el marrón // el azul // el metálico
        {
            Debug.Log("¡Enganchao'!");
            // evento al Engine.cs para que suba 
        }

        solidBlock = false;
    }
    */
    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().Rope += RaycastDirection;
    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().Rope -= RaycastDirection;
    }
}