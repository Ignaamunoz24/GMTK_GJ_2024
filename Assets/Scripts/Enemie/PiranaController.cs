using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranaController : MonoBehaviour
{
    public Transform posPlayer;
    public float speed;
    public float attackRate;
    public float nextAttack;
    public Rigidbody2D rb;

    Vector2 moveDirection;

<<<<<<< Updated upstream
<<<<<<< HEAD
    public Material abajo;
=======
>>>>>>> 85bc7233d111051d06ac6a48d24322eaaabcca5c
    bool onWater;

=======
    public Material abajo;
    bool onWater;

    private Animator animator;

>>>>>>> Stashed changes

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextAttack = Time.time;
<<<<<<< Updated upstream
<<<<<<< HEAD
=======

>>>>>>> 85bc7233d111051d06ac6a48d24322eaaabcca5c
=======
        animator = GetComponent<Animator>();
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
<<<<<<< Updated upstream
<<<<<<< HEAD
            onWater = true;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.blue;
=======
            onWater = true;
            animator.SetBool("isWater", true);
>>>>>>> Stashed changes
        }
        else if(collision.CompareTag("earth"))
        {
            onWater = false;
<<<<<<< Updated upstream
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
=======
            Debug.Log("en agua");
            onWater = true;
        }
        else if(collision.CompareTag("earth"))
        {
            Debug.Log("atacando");
            onWater = false;
>>>>>>> 85bc7233d111051d06ac6a48d24322eaaabcca5c
=======
            animator.SetBool("isWater", false);
>>>>>>> Stashed changes
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("earth"))
        {
<<<<<<< Updated upstream
<<<<<<< HEAD
            onWater = true;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.blue;
=======
            onWater = true;
            animator.SetBool("isWater", true);
>>>>>>> Stashed changes
        }
        else if (collision.CompareTag("water"))
        {
            onWater = false;
<<<<<<< Updated upstream
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
=======
            Debug.Log("en agua");
            onWater = true;
        }
        else if (collision.CompareTag("water"))
        {
            Debug.Log("atacando");
            onWater = false;
>>>>>>> 85bc7233d111051d06ac6a48d24322eaaabcca5c
=======
            animator.SetBool("isWater", false);
>>>>>>> Stashed changes
        }
    }

    void Attack()
    {
        moveDirection = (posPlayer.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }


    private void Update()
    {
        CheckIfTimeToAttack(); 

        if (onWater)
        {
            speed = 4f;
        }
        else if (!onWater)
        {
            speed = 0f;
        }
    }
    void CheckIfTimeToAttack()
    {
        if (Time.time > nextAttack && onWater) {
            Debug.Log("ATAQUE");
            Attack();
            nextAttack = Time.time + attackRate;
        }
    }

}
