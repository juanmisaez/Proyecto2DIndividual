using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    protected void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public virtual void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    protected void QuitGame()
    {
        Application.Quit();
    }
}