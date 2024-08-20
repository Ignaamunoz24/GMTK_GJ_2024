using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float velMov;
    private Vector2 direccion;
    private Rigidbody2D rb;

<<<<<<< Updated upstream
    public List<GameObject> vidas;

    public GameObject col;

    public Animator animator;

    void Start()
=======
    private float movX;
    private float movY;
    private Animator animator;

    public SpriteRenderer spriteRenderer;
    public Color waterColor = Color.blue;
    private Color originalColor;

    private bool isInWater = false;
    private bool isInEarth = false;

    public List<GameObject> vidas;

    private void Start()
>>>>>>> Stashed changes
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        currentSpeed = 0f;
        animator = GetComponent<Animator>();
=======

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        originalColor = spriteRenderer.color;
>>>>>>> Stashed changes
    }

    private void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("movX", movX);
        animator.SetFloat("movY", movY);
        direccion = new Vector2(movX, movY).normalized;

<<<<<<< Updated upstream
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
=======
        animator.SetBool("isInWater", isInWater);
        animator.SetBool("isInEarth", isInEarth);
>>>>>>> Stashed changes

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velMov * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            isInWater = true;
        }
        else if (other.CompareTag("earth"))
        {
            isInEarth = true;
        }
        UpdateSpriteColor();


        if (other.CompareTag("enemy1"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;

            if (vidas.Count > 0)
            {
                GameObject ultimoObjeto = vidas[vidas.Count - 1];

                Destroy(ultimoObjeto);

                vidas.RemoveAt(vidas.Count - 1);
            }
        }
    }

<<<<<<< Updated upstream
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
=======
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            isInWater = false;
        }
        else if (other.CompareTag("earth"))
        {
            isInEarth = false;
        }
        UpdateSpriteColor();

        if (other.CompareTag("enemy1"))
>>>>>>> Stashed changes
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
    }

<<<<<<< Updated upstream
}
=======
    private void UpdateSpriteColor()
    {
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
>>>>>>> Stashed changes
