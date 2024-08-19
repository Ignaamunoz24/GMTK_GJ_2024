using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float accelerationTime = 0.1f;  // Tiempo que tarda en alcanzar la velocidad máxima

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private float currentSpeed;

    public List<GameObject> vidas;

    public GameObject col;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Resetear moveInput a cero antes de evaluar la entrada
        moveInput = Vector2.zero;

        // Obtener la última tecla presionada para dar prioridad a esa dirección
        if (Input.GetKey(KeyCode.W))
        {
            moveInput = Vector2.up;
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput = Vector2.down;
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveInput = Vector2.left;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = Vector2.right;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }

        // Calcula la velocidad deseada basada en la entrada
        float targetSpeed = moveInput.magnitude * moveSpeed;

        // Lerp para la aceleración suave
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
            // Frenar en seco al dejar de presionar el botón
            currentSpeed = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy1"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;

            if (vidas.Count > 0)
            {
                // Obtén el último objeto en la lista
                GameObject ultimoObjeto = vidas[vidas.Count - 1];

                // Elimina el objeto de la escena
                Destroy(ultimoObjeto);

                // Elimina el objeto de la lista
                vidas.RemoveAt(vidas.Count - 1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy1"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
    }

}