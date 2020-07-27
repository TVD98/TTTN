using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
    public void BatDauGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ThoatGame()
    {
        Application.Quit();
    }

    
}
