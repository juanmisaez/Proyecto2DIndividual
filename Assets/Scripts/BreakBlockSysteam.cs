using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakBlockSysteam : MonoBehaviour
{
    public Tilemap groundTileMap;

    public float casDistance = 1.0f;
    public Transform raycastPoint;
    public LayerMask layer;

    float blockDestroyTime = 0.2f;

    Vector3 direction;
    RaycastHit2D hit;

    bool destroyingBlock = false;

    private InputSystemKeyboard _inputSystemKeyboard;

    private void Awake()
    {
        _inputSystemKeyboard = GetComponent<InputSystemKeyboard>();
    }

    /*void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.F))
        {
            RaycastDirection();
        }
    }*/

    void RaycastDirection()
    {
        if(_inputSystemKeyboard.hor != 0 || _inputSystemKeyboard.ver == -1)
        {
            direction.x = _inputSystemKeyboard.hor; //Input.GetAxis("Horizontal");
            direction.y = _inputSystemKeyboard.ver; //Input.GetAxis("Vertical");
        }

        hit = Physics2D.Raycast(raycastPoint.position, direction, casDistance, layer.value);
        
        Vector2 endpos = raycastPoint.position + direction;

        if(_inputSystemKeyboard.space)
        {
            if(hit.collider && !destroyingBlock)
            {
                destroyingBlock = true;
                StartCoroutine(DestroyBlock(hit.collider.gameObject.GetComponent<Tilemap>(), endpos));
            }
        }    
    }

    IEnumerator DestroyBlock(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(blockDestroyTime);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);

        destroyingBlock = false;
    }

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().Dig += RaycastDirection;
    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().Dig -= RaycastDirection;
    }
}