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
        //menuOptionsUI.SetActive(true);
        //background.SetActive(true);
        gameInOptions = true;
        IsPaused(gameInOptions);

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); // selecciona un nuevo objeto
    }

    public void CloseMenu()
    {
        //menuOptionsUI.SetActive(false);
        //background.SetActive(false);
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