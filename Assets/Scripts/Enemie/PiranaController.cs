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

<<<<<<< HEAD
    public Material abajo;
=======
>>>>>>> 85bc7233d111051d06ac6a48d24322eaaabcca5c
    bool onWater;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextAttack = Time.time;
<<<<<<< HEAD
=======

>>>>>>> 85bc7233d111051d06ac6a48d24322eaaabcca5c
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
<<<<<<< HEAD
            onWater = true;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.blue;
        }
        else if(collision.CompareTag("earth"))
        {
            onWater = false;
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("earth"))
        {
<<<<<<< HEAD
            onWater = true;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.blue;
        }
        else if (collision.CompareTag("water"))
        {
            onWater = false;
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
