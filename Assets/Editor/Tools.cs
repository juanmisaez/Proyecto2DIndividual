using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[ExecuteInEditMode()]

public class Tools : MonoBehaviour
{
    static int index = 0;

    [MenuItem("Implemented Tools/Activar-desactivar menus &#q", false, 1)] // & = alt, # = shit, q
    public static void AlternateAllMenuCanvas()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selected.Length > 0)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].gameObject.SetActive(!selected[i].gameObject.activeSelf);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Implemented Tools/Desactivar menus &#w", false, 1)] // & = alt, # = shit, w
    public static void DesactiveAllMenuCanvas()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selected.Length > 0)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].gameObject.SetActive(false);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Implemented Tools/Alternar menú activo &#e", false, 1)] // & = alt, # = shit, e
    public static void ActiveOneMenuCanvas()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selected.Length > 0)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].gameObject.SetActive(false);                        
            }
            selected[index].gameObject.SetActive(true);
            index++;

            if(index >= selected.Length)
            {
                index = 0;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero tienes que seleccionar un objeto", "Ok");
        }
    }
}