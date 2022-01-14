using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MenuSystem // Hacer un padre para los menús ****
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
    }

    public override void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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