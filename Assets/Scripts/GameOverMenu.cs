using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MenuSystem
{
    public static bool GameIsPaused = false;

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
        //Time.timeScale = 0f;
        GameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(selectedFirstButton); // selecciona un nuevo objeto
    }

    public void Retry()
    {
        //Time.timeScale = 1f;
        GameIsPaused = false;
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
