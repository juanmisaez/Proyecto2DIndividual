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

    public event Action Dig = delegate { };
    public event Action Hook = delegate { };
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
            space = Input.GetKeyDown(KeyCode.Space);
            escape = Input.GetKeyDown(KeyCode.Escape);

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
        //Debug.Log("--muerto actualizada: " + over);
    }

    void Options(bool _inOptions)
    {        
        options = _inOptions;
        //Debug.Log("--opciones actualizado: " + options);
    }

    void Cutscene(bool _inCutscene)
    {
        cutscene = _inCutscene;
    }

    void OnEnable()
    {
        //PauseMenu.IsPaused += Pause;
        OptionsMenu.IsPaused += Options;
        GameOverMenu.IsOver += Over;
        CutsceneManager.InCutscene += Cutscene;
    }
    void OnDisable()
    {
        //PauseMenu.IsPaused -= Pause;
        OptionsMenu.IsPaused -= Options;
        GameOverMenu.IsOver -= Over;
        CutsceneManager.InCutscene -= Cutscene;
    }
}