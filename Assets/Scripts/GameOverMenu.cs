using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MenuSystem // Hacer un padre para los men�s ****
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
        //GameIsPaused = true;
    }

    public void Retry()
    {
        //Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
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
