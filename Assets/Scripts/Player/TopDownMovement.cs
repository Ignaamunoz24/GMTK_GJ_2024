using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float accelerationTime = 0.1f;  // Tiempo que tarda en alcanzar la velocidad m�xima

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;
    }

    void Update()
    {
        // Resetear moveInput a cero antes de evaluar la entrada
        moveInput = Vector2.zero;

        // Obtener la �ltima tecla presionada para dar prioridad a esa direcci�n
        if (Input.GetKey(KeyCode.W))
        {
            moveInput = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveInput = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = Vector2.right;
        }

        // Calcula la velocidad deseada basada en la entrada
        float targetSpeed = moveInput.magnitude * moveSpeed;

        // Lerp para la aceleraci�n suave
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime / accelerationTime);

        // Calcular la velocidad final del movimiento
        moveVelocity = moveInput * currentSpeed;
    }

    void FixedUpdate()
    {
        // Mueve el personaje solo si hay entrada de movimiento
        if (moveInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
        else
        {
            // Frenar en seco al dejar de presionar el bot�n
            currentSpeed = 0f;
        }
    }
}