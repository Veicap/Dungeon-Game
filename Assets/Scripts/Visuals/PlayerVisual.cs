using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private EdgeCollider2D edgeCollider;
    private Vector2[] originalColliderPoints;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        if (edgeCollider != null)
        {
            originalColliderPoints = edgeCollider.points;
        }
    }
    private void Start()
    {
        Player.Instance.OnFlip += Player_OnFlip;
    }

    private void Player_OnFlip(object sender, Player.OnFlipEventArgs e)
    {
        if(e.moveHorizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (e.moveHorizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

}
