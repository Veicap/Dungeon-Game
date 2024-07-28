using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameUI : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
