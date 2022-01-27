using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class PauseMenu : MenuSystem
{
    public static event Action<bool> IsPaused = delegate { }; // Al Inputsystem

    public GameObject menuPauseUI;

    public static bool gameIsPaused = false;
    bool options;

    void Menu()
    {
        if (gameIsPaused == true && options == false)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {        
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        IsPaused(gameIsPaused);
    }

    void Pause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        IsPaused(gameIsPaused);

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(selectedFirstButton); // selecciona un nuevo objeto
    }

    void Options(bool _inOptions)
    {
        options = _inOptions;
    }

    public override void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    void OnEnable()
    {
        InputSystemKeyboard.Paused += Menu;
        OptionsMenu.IsPaused += Options;
    }
    void OnDisable()
    {
        InputSystemKeyboard.Paused -= Menu;
        OptionsMenu.IsPaused -= Options;
    }
}