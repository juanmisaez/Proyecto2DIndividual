using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class WinMenu : MenuSystem
{
    public static event Action<bool> IsPaused = delegate { }; // Al Inputsystem

    public GameObject menuWinUI;

    public static bool gameIsPaused;

    void Pause()
    {
        menuWinUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        IsPaused(gameIsPaused);
        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(selectedFirstButton); // selecciona un nuevo objeto
    }

    public void Retry()
    {
        gameIsPaused = false;
        IsPaused(gameIsPaused);
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        gameIsPaused = false;
        IsPaused(gameIsPaused);
        SceneManager.LoadScene("Credits");
    }

    void OnEnable()
    {
        CutsceneManager.WinGame += Pause;
    }
    void OnDisable()
    {
        CutsceneManager.WinGame -= Pause;
    }
}
