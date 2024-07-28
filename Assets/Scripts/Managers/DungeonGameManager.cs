using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGameManager : MonoBehaviour
{
    public static DungeonGameManager Instance {get; private set;}
    private float timeToLoseGame =1f;
    private float timeToWinGame = 0.5f;
    public event EventHandler OnLoseGame;
    public event EventHandler OnWinGame;
    private bool loseGame = false;
    private bool winGame = false;
    private void Start()
    {
        ButtonCanvasManager.Instance.OnResumeGame += ButtonCanvasManager_OnResumeGame;
    }

    private void ButtonCanvasManager_OnResumeGame(object sender, EventArgs e)
    {
        ResumeGame();
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(!LiveManager.Instance.IsAlive())
        {
            loseGame = true;

        }
        if(loseGame)
        {
            
            timeToLoseGame -= Time.deltaTime;
            if (timeToLoseGame < 0)
            {
                timeToLoseGame = 1f;
                OnLoseGame?.Invoke(this, EventArgs.Empty);  
                loseGame = false;
                PauseGame();
            }
        }
        if(Cup.Instance.IsWinGame() && !winGame)
        {
            winGame = true;
            
        }
        if (winGame)
        {
            timeToWinGame -= Time.deltaTime;
            if (timeToWinGame < 0)
            {
                timeToWinGame = 0.5f;
                PauseGame();
                OnWinGame?.Invoke(this, EventArgs.Empty);
                winGame = false;
            }
        }

    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
