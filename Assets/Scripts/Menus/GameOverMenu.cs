using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class GameOverMenu : MenuSystem
{
    public static event Action<bool> IsOver = delegate { }; // Al Inputsystem

    public GameObject menuGameOverUI;

    public static bool gameIsPaused;

    void Pause()
    {
        menuGameOverUI.SetActive(true);
        gameIsPaused = true;
        IsOver(gameIsPaused);
        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(selectedFirstButton); // selecciona un nuevo objeto
    }

    public void Retry()
    {
        gameIsPaused = false;
        IsOver(gameIsPaused);
        SceneManager.LoadScene("Game");
        GC.Collect();
    }

    void OnEnable()
    {
        OxygenSystem.Death += Pause;
    }
    void OnDisable()
    {
        OxygenSystem.Death -= Pause;
    }
}