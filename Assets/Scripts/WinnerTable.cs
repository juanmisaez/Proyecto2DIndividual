using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerTable : MonoBehaviour
{
    void Start()
    {
        DataBase.CreateDB();

        GetComponent<Text>().text = DataBase.WriteNames();
    }
}