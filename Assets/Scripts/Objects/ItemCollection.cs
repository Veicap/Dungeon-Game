using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    
    private BoxCollider2D boxCollider2D;
    [SerializeField] protected float timeToDestroy = 0.5f;
    protected bool isFirstTime = false;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public bool IsTouchingPlayer()
    {
        if(boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            return true;
        }
        return false;
    }
    
}
