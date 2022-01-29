using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuSystem : MonoBehaviour
{
    public GameObject selectedFirstButton;
    public GameObject optionsFirstButton;
    public GameObject optionsCloseButton;

    //public GameObject background;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // la escena del juego
    }

    public virtual void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); // la escena del menú de inicio
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}