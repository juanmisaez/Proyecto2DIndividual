using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform movePoint;
    [SerializeField]
    private LayerMask obstacle;

    private InputSystemKeyboard _inputSystem;
    private IsGrounded _isGrounded; // Comprobador de si toca el suelo

    void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        _isGrounded = GetComponent<IsGrounded>();
    }
        
    void Start()
    { 
        movePoint.parent = null; // se desvincula del padre
    }

    void Update()
    {        
        //--Move--//
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);        
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.5f)
        {
            if (Mathf.Abs(_inputSystem.hor) == 1f && _isGrounded.isGrounded)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(_inputSystem.hor, 0f, 0f), .1f, obstacle)) // Comprobar si coincide con la capa "obstacle"
                {
                    movePoint.position += new Vector3(_inputSystem.hor, 0f, 0f);
                }
            }
            // -------------------------------------------   
            // ** Provisional para saltar **
            /*else if (Mathf.Abs(_inputSystem.ver) == 1f && _isGrounded.isGrounded)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, _inputSystem.ver, 0f), .1f, obstacle)) // Comprobar si coincide con la capa "obstacle"
                {
                    movePoint.position += new Vector3(0f, _inputSystem.ver, 0f);
                }
            }*/
            // -------------------------------------------
        }
        //--Flip--//
        Vector3 scale = transform.localScale;

        if (_inputSystem.hor > 0)
        {
            scale.x = 1f;
        }
        if (_inputSystem.hor < 0)
        {
            scale.x = -1f;
        }
        transform.localScale = scale;                
    }
}