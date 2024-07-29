using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameUI : MonoBehaviour
{
    private bool isPause = false;
    private void Start()
    {
        
        InputManager.Instance.OnPause += InputManager_OnPause;
        gameObject.SetActive(false);
    }

    private void InputManager_OnPause(object sender, System.EventArgs e)
    {
        isPause = !isPause;
        if(isPause)
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}
