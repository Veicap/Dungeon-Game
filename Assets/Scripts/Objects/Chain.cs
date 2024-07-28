using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] Button buttonToUnlockSaw;

    private void Start()
    {
        buttonToUnlockSaw.OnUnlockTrap += ButtonToUnlockSaw_OnUnlockSaw;
    }

    private void ButtonToUnlockSaw_OnUnlockSaw(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }
}
