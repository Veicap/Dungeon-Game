using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleVisual : MonoBehaviour
{
    private Apple apple;
    private Animator animator;
    private readonly string IS_COLLECTED = "IsCollected";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        apple = GetComponent<Apple>();
    }
    private void Update()
    {
        animator.SetBool(IS_COLLECTED, apple.IsTouchingPlayer());
    }
}
