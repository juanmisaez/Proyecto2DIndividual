using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } 
    public float ver { get; private set; }
    public bool space { get; private set; }
    public bool escape { get; private set; }
    public bool w { get; private set; }
    public bool s { get; private set; }

    public event Action Dig = delegate { };
    public event Action Rope = delegate { };
    public static event Action Paused = delegate { }; // Al PauseMenu

    bool over;
    bool options;
    bool cutscene;

    void Update()
    {
        if (!cutscene)
        {
            hor = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");
            w = Input.GetKeyDown(KeyCode.W); //---
            s = Input.GetKeyDown(KeyCode.S); //---
            space = Input.GetKeyDown(KeyCode.Space);
            escape = Input.GetKeyDown(KeyCode.Escape);

            if(w)
            {
                Rope();
            }

            if (space)
            {
                Dig();
            }

            if (escape && over == false && options == false)
            {
                Paused();
            }
        }
    }

    void Over(bool _isOver)
    {
        over = _isOver;
    }

    void Options(bool _inOptions)
    {        
        options = _inOptions;
    }

    void Win(bool _isOver)
    {
        over = _isOver;
    }

    void Cutscene(bool _inCutscene)
    {
        cutscene = _inCutscene;
    }

    void OnEnable()
    {
        OptionsMenu.IsPaused += Options;
        GameOverMenu.IsOver += Over;
        WinMenu.IsPaused += Win;
        CutsceneManager.InCutscene += Cutscene;
    }
    void OnDisable()
    {
        OptionsMenu.IsPaused -= Options;
        GameOverMenu.IsOver -= Over;
        WinMenu.IsPaused -= Win;
        CutsceneManager.InCutscene -= Cutscene;
    }
}