using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MenuSystem
{
    public static bool GameIsPaused = false;

    public GameObject menuPauseUI;
    
    void Menu()
    {
        if (GameIsPaused)
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
        GameIsPaused = false;
    }

    void Pause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(selectedFirstButton); // selecciona un nuevo objeto
    }

    public override void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameIsPaused = false;
    }

    /*public void QuitGame()
    {
        Application.Quit();
    }*/

    // *********mirar otra forma**********
    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().PauseMenu += Menu;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().PauseMenu -= Menu;
    }
    // **********************************
}