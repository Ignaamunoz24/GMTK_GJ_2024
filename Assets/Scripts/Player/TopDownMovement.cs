using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float velMov;  // Velocidad de movimiento del personaje
    private Vector2 direccion;  // Dirección de movimiento del personaje
    private Rigidbody2D rb;  // Referencia al Rigidbody2D del personaje

    private float movX;
    private float movY;
    private Animator animator;  // Referencia al Animator del personaje

    public SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer del personaje
    public Color waterColor = Color.blue;  // Color cuando el personaje está en agua
    private Color originalColor;  // Color original del Sprite

    private bool isInWater = false;  // Indica si el personaje está en agua
    private bool isInEarth = false;  // Indica si el personaje está en tierra

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        originalColor = spriteRenderer.color;  // Guarda el color original del Sprite
    }

    private void Update()
    {
        // Manejo de movimiento
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("movX", movX);
        animator.SetFloat("movY", movY);
        direccion = new Vector2(movX, movY).normalized;

        // Actualizar parámetros del Animator
        animator.SetBool("isInWater", isInWater);
        animator.SetBool("isInEarth", isInEarth);
    }

    private void FixedUpdate()
    {
        // Aplicar movimiento al Rigidbody2D
        rb.MovePosition(rb.position + direccion * velMov * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar si el personaje entra en agua o tierra
        if (other.CompareTag("water"))
        {
            isInWater = true;
        }
        else if (other.CompareTag("earth"))
        {
            isInEarth = true;
        }
        UpdateSpriteColor();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detectar si el personaje sale del agua o tierra
        if (other.CompareTag("water"))
        {
            isInWater = false;
        }
        else if (other.CompareTag("earth"))
        {
            isInEarth = false;
        }
        UpdateSpriteColor();
    }

    private void UpdateSpriteColor()
    {
        // Cambiar el color del sprite según las condiciones
        if (isInWater && !isInEarth)
        {
            spriteRenderer.color = waterColor;
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
    }
}
