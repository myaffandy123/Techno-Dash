using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer playerSprite;

    [SerializeField] private int speedX = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speedX, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.gravityScale = - rb.gravityScale;
        }

        UpdateAnimation();
        
    }

    private void UpdateAnimation()
    {
        // Animasi kanan kiri dan lari
        if (rb.velocity.x > 0)
        {
            animator.SetBool("running", true);
            playerSprite.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            animator.SetBool("running", true);
            playerSprite.flipX = true;
        }
        else
        {
            animator.SetBool("running", false);
        }

        // Animasi atas bawah
        if (rb.gravityScale > 0)
        {
            playerSprite.flipY = false;
        }
        else if (rb.gravityScale < 0)
        {
            playerSprite.flipY = true;
        }
        
    }
}
