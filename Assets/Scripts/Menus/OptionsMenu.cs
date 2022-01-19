using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsMenu : MenuSystem
{
    //public GameObject menuOptionsUI;

    public void OptionMenu()
    {
        //menuOptionsUI.SetActive(true); // activa la interfaz correspondiente del canvas

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); // selecciona un nuevo objeto
    }

    public void CloseMenu()
    {
        //menuOptionsUI.SetActive(false); // desactiva la interfaz correspondiente del canvas

        EventSystem.current.SetSelectedGameObject(null); // limpia el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(optionsCloseButton); // selecciona un nuevo objeto
    }
}