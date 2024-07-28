using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTrapVisual : MonoBehaviour
{
    [SerializeField] GameObject interactMotionTrapGameObject;
    private Animator animator;
    private readonly string IS_DESTROY = "IsDestroy";
    private bool isTouching = false;
    private IInteractMotionTrap interactMotionTrap;
    private void Awake()
    {
        if (interactMotionTrap == null)
        {
            interactMotionTrap = interactMotionTrapGameObject.GetComponent<IInteractMotionTrap>();
        }
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(interactMotionTrap.IsTouchingMotionTrap())
        {
            isTouching = true;
        }
        if(isTouching)
        {
            animator.SetBool(IS_DESTROY, true);
        }
    }
}
