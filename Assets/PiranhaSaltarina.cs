using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaSaltarina : MonoBehaviour
{
    public float moveSpeed = 3f;          // Velocidad de movimiento en estado de reposo
    public float attackSpeed = 6f;        // Velocidad de ataque
    public float attackDelay = 3f;        // Tiempo que la piraña reposa antes de atacar
    private float attackCooldown;         // Temporizador para el ataque
    private Rigidbody2D rb;
    public Transform player;
    private bool isInWater = false;       // Indica si la piraña está en agua
    private bool isInEarth = false;       // Indica si la piraña está en tierra
    private bool isResting = true;        // Estado actual: reposo o ataque
    private bool isAttacking = false;     // Indica si la piraña está en ataque
    private Vector2 attackDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackCooldown = attackDelay;
        StartCoroutine(FindPlayer());
    }

    void Update()
    {
        if (isAttacking)
        {
            AttackPlayer();
        }
        else if (isResting && isInWater)
        {
            PursuePlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            isInWater = true;
        }
        else if (other.CompareTag("earth"))
        {
            isInEarth = true;
        }
        UpdateState();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            isInWater = false;
        }
        else if (other.CompareTag("earth"))
        {
            isInEarth = false;
        }
        UpdateState();
    }

    IEnumerator FindPlayer()
    {
        while (true)
        {
            if (player == null)
            {
                // Buscar al jugador en la escena
                GameObject playerObj = GameObject.FindWithTag("Player");
                if (playerObj != null)
                {
                    player = playerObj.transform;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void PursuePlayer()
    {
        if (player == null) return;

        // Seguir al jugador
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // Verificar si la Piraña está en el borde de la tierra y cambiar a estado de ataque
        if (isInEarth)
        {
            StartCoroutine(PrepareAttack());
        }
    }

    IEnumerator PrepareAttack()
    {
        isResting = false;
        rb.velocity = Vector2.zero; // Detener el movimiento mientras reposa
        yield return new WaitForSeconds(attackDelay);

        // Preparar ataque
        if (player != null)
        {
            attackDirection = (player.position - transform.position).normalized;
            isAttacking = true;
        }
    }

    void AttackPlayer()
    {
        rb.velocity = attackDirection * attackSpeed;

        // Verificar si la Piraña está en agua después del ataque
        if (isInWater)
        {
            isAttacking = false;
            isResting = true;
            rb.velocity = Vector2.zero; // Detener el movimiento al regresar a reposo
        }
    }

    void UpdateState()
    {
        // Actualizar el estado basado en las condiciones actuales
        if (isInWater && !isInEarth)
        {
            isResting = true;
        }
        else if (isInEarth)
        {
            isResting = false;
        }
    }
}