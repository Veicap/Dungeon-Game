using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private readonly string IS_WALKING = "IsWalking";
    private readonly string IS_JUMPING = "IsJumping";
    private readonly string IS_HIT = "IsHit";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool(IS_HIT, Player.Instance.IsTrap());
        animator.SetBool(IS_WALKING, Player.Instance.IsWalking());
        animator.SetBool(IS_JUMPING, Player.Instance.IsJumping());
    }
}
