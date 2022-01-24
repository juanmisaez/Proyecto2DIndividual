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

    private bool walkableLayer;
    private bool roofLayer; //---TEST---


    private InputSystemKeyboard _inputSystem;
    public Rigidbody2D ballRb;
    private Rigidbody2D _playerRb;

    //private IsGrounded _isGrounded; // Comprobador de si toca el suelo

    void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        //_isGrounded = GetComponent<IsGrounded>(); // tecnicamente ya no hace falta
        _playerRb = GetComponent<Rigidbody2D>();
    }
        
    void Start()
    { 
        movePoint.parent = null; // se desvincula del padre
    }

    void Update()
    {
        bool obstacleHor = Physics2D.OverlapCircle(movePoint.position + new Vector3(_inputSystem.hor, 0f, 0f), .1f, obstacle); // Comprobar si coincide con la capa "obstacle" 
        bool obstacleVer = Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, _inputSystem.ver, 0f), .1f, obstacle); // Comprobar si coincide con la capa "obstacle" 

        //--Move--//
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);        
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.5f)
        {
            if (Mathf.Abs(_inputSystem.hor) == 1f && (walkableLayer == true || roofLayer == true))
            {
                if (!obstacleHor)
                {
                    if (Mathf.Sign(ballRb.gravityScale) == -1)
                    {
                        ballRb.gravityScale *= -1;
                    }
                    movePoint.position += new Vector3(_inputSystem.hor, 0f, 0f);
                }
            }
            // -------------------------------------------   
            // ** Provisional para saltar **
            else if (Mathf.Abs(_inputSystem.ver) == 1f && walkableLayer == true )
            {
                if (!obstacleVer) // hor
                {
                    ballRb.gravityScale *= -1;

                    /*for(int i = 0; i < 2; i++)
                    {                        
                        movePoint.position += new Vector3(0f, _inputSystem.ver + i, 0f);
                    }*/

                    //_playerRb.velocity = new Vector2(_playerRb.velocity.x, 10);
                    //ballRb.velocity = new Vector2(ballRb.velocity.x, 10);
                }
            }
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

    void OnGround(bool onGrounded, bool onStructure)
    {
        if(onGrounded == false && onStructure == false)
        {
            walkableLayer = false;
        }
        else
        {
            walkableLayer = true;
        }
    }
    //---------------TEST------------------
    void UnderRoof(bool underGround, bool underStructure)
    {
        if(underGround == false && underStructure == false)
        {
            roofLayer = false;
        }
        else
        {
            roofLayer = true;
        }
    }
    //---------------TEST------------------

    void OnEnable()
    {
        GetComponent<IsGrounded>().Ground += OnGround;
        GetComponent<IsGrounded>().Roof += UnderRoof; //---TEST---
    }

    void OnDisable()
    {
        GetComponent<IsGrounded>().Ground -= OnGround;
        GetComponent<IsGrounded>().Roof -= UnderRoof; //---TEST---
    }
}