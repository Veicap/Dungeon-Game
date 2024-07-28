using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Collider2D tranpolineCollider2D;
    private void Awake()
    {
        tranpolineCollider2D = GetComponent<Collider2D>();
    }
    public bool IsTouchingPlayer()
    {
        if(tranpolineCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            return true;
        }
        return false;
    }
}
