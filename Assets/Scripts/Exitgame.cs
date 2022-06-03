using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitgame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Bye");
            Application.Quit();
        }
    }
}
