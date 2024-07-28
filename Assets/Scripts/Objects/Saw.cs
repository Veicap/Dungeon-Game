using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, IInteractMotionTrap
{
    [SerializeField] Button buttonToUnlockSaw;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private bool isPressButton = false;
    //private event EventHandler OnTouchingTrap;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(buttonToUnlockSaw.IsPlayPressButton())
        {
            isPressButton = true;
        }
        if(isPressButton)
        {
            rb.velocity = new Vector2(-3f, rb.velocity.y);
        }
       
    }
    public bool IsTouchingMotionTrap()
    {
        if(circleCollider.IsTouchingLayers(LayerMask.GetMask("MotionTrap")))
        {
            return true;
        }
        return false;
    }

}
