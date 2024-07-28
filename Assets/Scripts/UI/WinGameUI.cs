using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinGameUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI numberOfAppleAchive;
    private int numberOfAppleSpawn;

    private void Start()
    {
        numberOfAppleSpawn = 36;
        DungeonGameManager.Instance.OnWinGame += DungeonGameManager_OnWinGame;
        gameObject.SetActive(false);
    }

    private void DungeonGameManager_OnWinGame(object sender, System.EventArgs e)
    {
        string achivement = ItemCollectedManager.Instance.GetNumberOfAppleCollected().ToString() + " / " + numberOfAppleSpawn;
        gameObject.SetActive(true);
        numberOfAppleAchive.text = achivement;
    }
}
