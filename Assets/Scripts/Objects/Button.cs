using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event EventHandler OnUnlockTrap;
    private BoxCollider2D boxCollider2D;
    private bool isUnlock = false;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void  Update()
    {
        if(IsPlayPressButton())
        {
            if(!isUnlock)
            {
                OnUnlockTrap?.Invoke(this, EventArgs.Empty);
                isUnlock = true;
            }
            
        }
    }
    public bool IsPlayPressButton()
    {
        if(boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            return true;
        }
        return false;
    }
}
