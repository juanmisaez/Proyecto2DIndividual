using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } 
    public float ver { get; private set; }
    public bool space { get; private set; } //---

    public event Action Dig = delegate { };
    public event Action Hook = delegate { };
    public event Action PauseMenu = delegate { };

    public StartIntro _startIntro; // Para comprobador si est� en la "cinem�tica"
    
    void Update()
    {
        if (!_startIntro.isCutsceneOn )
        {
            hor = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");
            space = Input.GetKey(KeyCode.Space); //---
            
            if (Input.GetKey(KeyCode.Escape))
            {
                PauseMenu();
            }

            if (space)//Input.GetKey(KeyCode.Space)) //---
            {
                Dig();
            }
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Hook(); // ---
            }*/
        }
    }
}