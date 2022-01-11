using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour // Hacer un padre para los menús ****
{
    public static bool GameIsPaused = false;

    public GameObject menuPauseUI;
    
    /*void Update() // No hace falta ********
    {
        /*if (Input.GetKeyDown(KeyCode.Escape)) // sacar evento de InputSystemKeyboard *************
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }*/

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

    public void LoadMenu()
    {
        Debug.Log("Cargando menú...");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");
    }

    public void QuitMenu()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().PauseMenu += Menu;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().PauseMenu -= Menu;
    }
}