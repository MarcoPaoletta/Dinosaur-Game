using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    public GameObject gameOverScreen;
    public LayerMask ground;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private Animator animator;
    private float radius; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        radius = 0.2f;
    }

    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        animator.SetBool("isGrounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * 800);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Ground"))    
        {
            gameOverScreen.SetActive(true);
            animator.SetTrigger("die");
            Time.timeScale = 0f;
        }    
    }
}
