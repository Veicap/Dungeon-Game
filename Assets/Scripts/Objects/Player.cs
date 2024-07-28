using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float speed = 5;
    private float moveHorizontal;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;
    [SerializeField] private float jumpForce;
    [SerializeField] Trampoline trampoline;
    [SerializeField] private float jumpForceByTrampoline;
    public event EventHandler<OnFlipEventArgs> OnFlip;
    public class OnFlipEventArgs: EventArgs
    {
        public float moveHorizontal;
    }
    public float freezeDuration = 0.5f; 
    public float counterFreeze = 0f;
    private bool isFrozen = false; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        InputManager.Instance.OnJump += InputManager_OnJump;
    }
    private void InputManager_OnJump(object sender, System.EventArgs e)
    {
        if (!isFrozen)
        {
            Jump();
        }
        
    }
    private void Update()
    {
        
        
        if (!isFrozen)
        {
            HandleMovement();
        }
        JumpByTrampoline();
    }
    public bool IsJumping()
    {
        if (rb.velocity.y > 1f)
        {
            return true;
        }
        return false;
    }
    private void JumpByTrampoline()
    {
        if (trampoline.IsTouchingPlayer())
        {
            rb.AddForce(Vector2.up * jumpForceByTrampoline, ForceMode2D.Impulse);
        }
    }
    private void HandleMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        OnFlip?.Invoke(this, new OnFlipEventArgs
        {
            moveHorizontal = moveHorizontal
        });
        
    }
    private void Jump()
    {
        if(IsTouchingLayerPlatform())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }
    public bool IsTouchingLayerPlatform()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
            capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Trap")))
        {
            return true;
        }
        return false;
    }
    public bool IsTrap()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Trap")) ||
            capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Saw"))  ||
            capsuleCollider.IsTouchingLayers(LayerMask.GetMask("MotionTrap")))
        {
            return true;
        }
        return false;
    }
    public float GetMoveHorizontal()
    {
         return moveHorizontal;
    }
    public bool IsWalking()
    {
        if (moveHorizontal != 0)
        {
            return true;
        }
        return false;
    }
    public bool IsPlayerTouchingItems()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Items")))
        {
            return true;
        }
        return false;
    }
   
}
