using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } 
    public float ver { get; private set; }
    public bool space { get; private set; }

    public event Action Dig = delegate { };
    public event Action Hook = delegate { };
    public event Action PauseMenu = delegate { };

    //public CollisionCutscene _cutscene; //-------
    //public CollisionCapataz _capataz;

    void Update()
    {
        //if (!_cutscene.isCutsceneOn && !_capataz.isCutsceneOn)
        //{
            hor = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");
            space = Input.GetKeyUp(KeyCode.Space);
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu();
            }

            if (space)
            {
                Dig();
            }

            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                Hook(); // ---
            }*/
        //}
    }
}