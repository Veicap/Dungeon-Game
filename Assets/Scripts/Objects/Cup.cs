using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public static Cup Instance { get; private set; }
    private BoxCollider2D collider2DCup;
   
    private void Awake()
    {
        Instance = this;
        collider2DCup = GetComponent<BoxCollider2D>();
    }
    public bool IsWinGame()
    {
        if(collider2DCup.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            return true;
        }
        return false;
    }

}
