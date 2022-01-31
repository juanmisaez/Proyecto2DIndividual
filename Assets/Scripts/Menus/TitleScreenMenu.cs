using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class TitleScreenMenu : MenuSystem
{    
    public GameObject titleScreenUI;
    public GameObject background;    
    public GameObject nextUI;
    public GameObject nextBackgorund;

    public bool gameInTitleScreen = true;

    private void Update()
    {
        if (Input.anyKey && gameInTitleScreen)
        {
            NextScreen();
        }
    }

    private void NextScreen()
    {        
        background.SetActive(false);
        titleScreenUI.SetActive(false);

        nextBackgorund.SetActive(true);
        nextUI.SetActive(true);

        gameInTitleScreen = false;
    }
}