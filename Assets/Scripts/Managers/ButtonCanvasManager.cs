using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCanvasManager : MonoBehaviour
{
    public static ButtonCanvasManager Instance { get; private set; }
    public event EventHandler OnResumeGame;
    public bool isLoadNewGame = false;
    private void Awake()
    {
        Instance = this; 
    }
    public void LoadNewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        isLoadNewGame=true;
    }
    public void LoadMainMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
       
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
    
}
