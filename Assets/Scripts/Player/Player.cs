using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    Rigidbody2D myrigidbody2D;
    [SerializeField] private float moveSpeed = 5.0f;
    private bool grounded = false;
    private bool resetJump = false;
    private PlayerAnimation playeranum;
    private SpriteRenderer PlayerSpriteFliper;
    private SpriteRenderer SwordArcSprite;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        playeranum = GetComponent<PlayerAnimation>();
        PlayerSpriteFliper = GetComponentInChildren<SpriteRenderer>();
        SwordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0) && IsGrounded()==true)
        {
            Attack();
        }
    }
    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();
        FlipSprites(horizontal);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, _jumpForce);
            playeranum.Jump(true);
            StartCoroutine(ResetJumpRoutine());
        }
        myrigidbody2D.velocity = new Vector2(horizontal * moveSpeed, myrigidbody2D.velocity.y);
        playeranum.Move(horizontal);
    }
    private void Attack()
    {
            playeranum.Attack();
    }

    private void FlipSprites(float horizontal)
    {
        if (horizontal > 0)
        {
            PlayerSpriteFliper.flipX = false;
            SwordArcSprite.flipX = false;
            SwordArcSprite.flipY = false;
            Vector3 newPos = SwordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            SwordArcSprite.transform.localPosition = newPos;
        }
        else if (horizontal < 0)
        {
            PlayerSpriteFliper.flipX = true;
            SwordArcSprite.flipX = true;
            SwordArcSprite.flipY = true;
            Vector3 newPos = SwordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            SwordArcSprite.transform.localPosition = newPos;
        }
    }

    private bool IsGrounded()
    {
       RaycastHit2D hitInfo =  Physics2D.Raycast(transform.position, Vector2.down * 1f, 1<<10);
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        if(hitInfo.collider != null)
        { 
            if(resetJump == false)
            {
                playeranum.Jump(false);
                return true;
            }
        }
        return false;
    }
    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(1f);
        resetJump = false;
    }
}
