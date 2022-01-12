using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour // Hacer un padre para los menús ****
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
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameIsPaused = false;
    }

    public void QuitMenu()
    {
        Application.Quit();
    }

    /*void OnEnable()
    {
        GetComponent<OxygenSystem>().Death += Pause;
    }
    void OnDisable()
    {
        GetComponent<OxygenSystem>().Death -= Pause;
    }*/
}
