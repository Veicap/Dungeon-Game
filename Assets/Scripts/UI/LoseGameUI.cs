using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameUI : MonoBehaviour
{
    private void Start()
    {
        DungeonGameManager.Instance.OnLoseGame += DungeonGameManager_OnLoseGame;
        gameObject.SetActive(false);
    }

    private void DungeonGameManager_OnLoseGame(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }
}
