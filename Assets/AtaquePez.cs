using System.Collections;
using UnityEngine;

public class AtaquePez : MonoBehaviour
{
    public Transform target; // El objetivo, que es el jugador
    public float speed = 2f; // Velocidad normal
    public float jumpSpeed = 5f; // Velocidad aumentada durante el "salto"
    public float jumpHeight = 2f; // Altura del "salto"
    public float jumpDuration = 1f; // Duración del "salto"
    private bool isJumping = false;
    private Vector3 jumpTarget;
    private Coroutine jumpCoroutine;

    void Update()
    {
        if (!isJumping)
        {
            // Movimiento normal hacia el jugador
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Simulación del salto
            transform.position = Vector3.MoveTowards(transform.position, jumpTarget, jumpSpeed * Time.deltaTime);
            if (transform.position == jumpTarget)
            {
                isJumping = false; // Termina el salto cuando alcanza la posición del objetivo
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta si el enemigo entra en el rango de ataque (trigger)
        if (other.CompareTag("earth") && !isJumping)
        {
            jumpCoroutine = StartCoroutine(WaitAndJumpAttack());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Detecta si el enemigo sale del rango de ataque (trigger)
        if (other.CompareTag("earth") && isJumping)
        {
            StopCoroutine(jumpCoroutine); // Detener el salto si está ocurriendo
            isJumping = false; // Cambiar el estado de salto
        }
    }

    IEnumerator WaitAndJumpAttack()
    {
        yield return new WaitForSeconds(2f); // Esperar 2 segundos antes de iniciar el ataque
        yield return JumpAttack(); // Ejecutar el ataque después de esperar
    }

    IEnumerator JumpAttack()
    {
        isJumping = true;

        // Calcular la posición del salto
        Vector3 startPosition = transform.position;
        Vector3 playerPosition = target.position;

        // Definir la posición del "salto" (pasar por encima del jugador)
        jumpTarget = new Vector3(playerPosition.x, playerPosition.y + jumpHeight, playerPosition.z);

        // Esperar un tiempo antes de caer (simulación de salto)
        yield return new WaitForSeconds(jumpDuration);

        // Caída hacia una posición más allá del jugador
        while (transform.position.x < playerPosition.x)
        {
            // Continuar moviéndose hacia adelante hasta pasar al jugador
            jumpTarget = playerPosition + (playerPosition - startPosition).normalized * 2f;
            transform.position = Vector3.MoveTowards(transform.position, jumpTarget, jumpSpeed * Time.deltaTime);
            yield return null;
        }

        isJumping = false;
    }
}
