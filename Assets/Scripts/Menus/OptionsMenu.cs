using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using System;

public class OptionsMenu : MenuSystem
{
    public static event Action<bool> IsPaused = delegate { }; // Al Inputsystem y al PauseMenu

    public static bool gameInOptions = true;

    public GameObject menuOptionsUI;
    public AudioMixer audioMixer; //---

    public void OptionMenu()
    {
        gameInOptions = true;
        IsPaused(gameInOptions);

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); // selecciona un nuevo objeto
    }

    public void CloseMenu()
    {
        gameInOptions = false;
        IsPaused(gameInOptions);

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsCloseButton); // selecciona un nuevo objeto
    } 
    
    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol); //---
    }
}