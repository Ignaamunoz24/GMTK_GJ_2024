using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownMovement : MonoBehaviour
{
    public float velMov;
    private Vector2 direccion;
    private Rigidbody2D rb;

    private float movX;
    private float movY;
    private Animator animator;

    public SpriteRenderer spriteRenderer;
    public Color waterColor = Color.blue;
    private Color originalColor;

    private bool isInWater = false;
    private bool isInEarth = false;

    public List<GameObject> vidas;
    public int maxVidas = 3;

    public GameObject growSword;

    public GameObject ultimoObjeto;

    public GameObject panelLose;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("movX", movX);
        animator.SetFloat("movY", movY);
        direccion = new Vector2(movX, movY).normalized;

        animator.SetBool("isInWater", isInWater);
        animator.SetBool("isInEarth", isInEarth);

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

            // Buscar el último objeto activo y desactivarlo
            for (int i = maxVidas - 1; i >= 0; i--)
            {
                if (vidas[i].activeSelf)
                {
                    vidas[i].SetActive(false);
                    CheckVidas();
                    break;
                }
            }
        }

        if (other.CompareTag("grow"))
        {
            growSword.SetActive(true);
            Invoke("cancelGrow", 5f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("health"))
        {
            for (int i = 0; i < maxVidas; i++)
            {
                if (!vidas[i].activeSelf)
                {
                    vidas[i].SetActive(true);
                    break;
                }
            }
            Destroy(other.gameObject);
        }


        if (other.CompareTag("salida"))
        {
            SceneManager.LoadScene("PlayableScene");
        }
    }

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
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
    }

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

    void cancelGrow()
    {
        growSword.SetActive(false);
    }

    void CheckVidas()
    {
        bool vidaRestante = false;
        foreach (var vida in vidas)
        {
            if (vida.activeSelf)
            {
                vidaRestante = true;
                break;
            }
        }

        if (!vidaRestante)
        {
            panelLose.SetActive(true);

            GameObject player = GameObject.Find("Player");
            TopDownMovement scriptToRemove = player.GetComponent<TopDownMovement>();

            GameObject controlador = GameObject.Find("ControladorPS");
            spawnerPirana scripts = controlador.GetComponent<spawnerPirana>();

            if (scriptToRemove != null)
            {
                scriptToRemove.enabled = false;
                Destroy(scripts);
            }
        }
    }

}
