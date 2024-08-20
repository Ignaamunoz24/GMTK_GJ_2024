using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    public float speed = 2f; // Velocidad del enemigo
    private bool shouldMove = true; // Controla si el enemigo debe moverse

    void Start()
    {
        // Ignorar colisiones entre objetos de la capa "Enemy"
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"));
    }

    void Update()
    {
        // Mover al enemigo hacia el jugador si debe moverse
        if (target != null && shouldMove)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el enemigo colisiona con el colider del jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Golpe"); // Imprimir "Golpe" en la consola
            shouldMove = false; // Detener el movimiento del enemigo
        }
    }
}
