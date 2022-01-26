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

    public event Action Dig = delegate { };
    public event Action Hook = delegate { };
    public static event Action PauseMenu = delegate { };

    bool pause;
    bool options;
    bool cutscene;

    void Update()
    {
        if (!cutscene)
        {
            hor = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");
            space = Input.GetKeyDown(KeyCode.Space);
            //escape = Input.GetKeyDown(KeyCode.Escape);

            if (space)
            {
                Dig();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !pause && !options)
            {
                PauseMenu();
            }
        }
    }

    void Pause(bool _isPause)
    {
        pause = _isPause;
    }

    void Options(bool _inOptions)
    {
        options = _inOptions;
    }

    void Cutscene(bool _inCutscene)
    {
        cutscene = _inCutscene;
    }

    void OnEnable()
    {
        GameOverMenu.IsPaused += Pause;
        OptionsMenu.InOptions += Options;
        CutsceneManager.InCutscene += Cutscene;
    }
    void OnDisable()
    {
        GameOverMenu.IsPaused -= Pause;
        OptionsMenu.InOptions -= Options;
        CutsceneManager.InCutscene -= Cutscene;
    }
}