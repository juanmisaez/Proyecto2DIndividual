using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class GameOverMenu : MenuSystem
{
    public static event Action<bool> IsPaused = delegate { };

    public static bool gameIsPaused;

    public GameObject menuGameOverUI;
    public OxygenSystem _oxygenSystem;

    void Update()
    {
        if(_oxygenSystem.GetOxygen() <= 0)
        {
            Pause();            
        }
    }

    void Pause()
    {
        menuGameOverUI.SetActive(true);
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

    /*public void LoadMenu()
    {
        //Time.timeScale = 1f;
        //GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }*/

    /*public void QuitGame()
    {
        Application.Quit();
    }*/

    /*void OnEnable()
    {
        GetComponent<OxygenSystem>().Death += Pause;
    }
    void OnDisable()
    {
        GetComponent<OxygenSystem>().Death -= Pause;
    }*/
}
