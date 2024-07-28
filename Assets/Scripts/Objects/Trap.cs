using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IInteractMotionTrap
{
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Button button;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        button.OnUnlockTrap += Button_OnUnLockTrap;
        gameObject.SetActive(false);
    }

    private void Button_OnUnLockTrap(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }

    public bool IsTouchingMotionTrap()
    {
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("MotionTrap")))
        {
            return true;
        }
        return false;
    }
}
