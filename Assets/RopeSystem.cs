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
    public LayerMask layer;

    public float blockDestroyTime = 1f;

    Vector3 direction;
    RaycastHit2D hit;

    bool solidBlock = false;

    private InputSystemKeyboard _inputSystemKeyboard;

    void RaycastDirection()
    {
        hit = Physics2D.Raycast(raycastPoint.position, direction, casDistance, layer.value);

        Vector2 rope2 = raycastPoint.position + direction * 2;   // distancia de 3 tiles, valor a modificar para aumentar la cuerda
        Vector2 hook1;
        hook1.x = rope2.x + direction.x;
        hook1.y = rope2.y + direction.y;

        Debug.DrawLine(raycastPoint.position, rope2, Color.red); // la cuerda
        Debug.DrawLine(rope2, hook1, Color.cyan);                // gancho

        if (_inputSystemKeyboard.space)
        {
            if (hit.collider && !solidBlock)
            {
                solidBlock = true;
                StartCoroutine(DestroyBlock(hit.collider.gameObject.GetComponent<Tilemap>(), rope2));
            }
        }
    }

    IEnumerator DestroyBlock(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(blockDestroyTime);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        TileBase t = map.GetTile(new Vector3Int((int)pos.x, (int)pos.y, 0));
                

        if (t.name == "Terreno_4") // el marrón
        {
            //map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
        }
        if (t.name == "Terreno_5") // el azul
        {
            //map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
        }
        if (t.name == "Terreno_6") // el metálico
        {
            //map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
        }

        solidBlock = false;
    }


    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().Rope += RaycastDirection;
    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().Rope -= RaycastDirection;
    }
}