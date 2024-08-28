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

    public GameObject[] jugador;

    Vector2 moveDirection;

    public Material abajo;
    bool onWater;

    private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextAttack = Time.time;
        animator = GetComponent<Animator>();

        jugador = GameObject.FindGameObjectsWithTag("Player");

        posPlayer = jugador[0].transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            onWater = true;
            animator.SetBool("isWater", true);
        }
        else if(collision.CompareTag("earth"))
        {
            onWater = false;
            animator.SetBool("isWater", false);
        }

        if (collision.CompareTag("sword"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("earth"))
        {
            onWater = true;
            animator.SetBool("isWater", true);
        }
        else if (collision.CompareTag("water"))
        {
            onWater = false;
            animator.SetBool("isWater", false);
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
