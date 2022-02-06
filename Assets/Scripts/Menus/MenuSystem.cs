using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class MenuSystem : MonoBehaviour
{
    public GameObject selectedFirstButton;
    public GameObject optionsFirstButton;
    public GameObject optionsCloseButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // la escena del juego
        GC.Collect();
    }

    public virtual void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); // la escena del menú de inicio
        GC.Collect();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}