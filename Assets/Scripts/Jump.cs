using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public KeyCode jumpKey;

    bool isJumping = false;
    bool isOnGround = false;

    int extraJumps = 1;

    public Animator animator;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                if (isOnGround)
                {
                    isJumping = true;
                    animator.SetTrigger("jump");
                }
                else if (extraJumps > 0)
                {
                    isJumping = true;
                    extraJumps--;
                    animator.SetTrigger("jump");
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(new Vector2(0, 9f), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collider2D)
    {
        isOnGround = true;
        extraJumps = 1;
    }

    void OnCollisionExit2D(Collision2D collider2D)
    {
        isOnGround = false;
    }
}