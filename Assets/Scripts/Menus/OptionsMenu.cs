using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class OptionsMenu : MenuSystem
{
    public static event Action<bool> InOptions = delegate { };

    public static bool gameInOptions = true;

    public GameObject menuOptionsUI;

    public void OptionMenu()
    {
        menuOptionsUI.SetActive(true);
        gameInOptions = true;
        InOptions(gameInOptions);

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); // selecciona un nuevo objeto
    }

    public void CloseMenu()
    {
        menuOptionsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsCloseButton); // selecciona un nuevo objeto
    }
}