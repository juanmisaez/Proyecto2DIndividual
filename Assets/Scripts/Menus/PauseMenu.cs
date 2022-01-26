using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MenuSystem
{
    public static bool gameIsPaused = false;

    public GameObject menuPauseUI;
    
    void Menu()
    {
        if (gameIsPaused)
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
    }

    void Pause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(selectedFirstButton); // selecciona un nuevo objeto
    }

    public override void LoadMenu()
    {
        menuPauseUI.SetActive(false);
    }

    void OnEnable()
    {
        InputSystemKeyboard.PauseMenu += Menu;
    }
    void OnDisable()
    {
        InputSystemKeyboard.PauseMenu -= Menu;
    }
}