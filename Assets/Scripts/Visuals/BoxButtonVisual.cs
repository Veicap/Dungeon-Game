using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class BoxButtonVisual : MonoBehaviour
{
    private Animator animator;
    private readonly string IS_PLAYER_PRESS = "IsPlayerPress";
    private Button button;
    private bool isPressed = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }
    private void Update()
    {
        if(button.IsPlayPressButton())
        {
            if (isPressed)
            {
                animator.SetBool(IS_PLAYER_PRESS, true);
                isPressed = false;
            }
            else
            {
                animator.SetBool(IS_PLAYER_PRESS, false);
            }   
        }
       

    }


}
