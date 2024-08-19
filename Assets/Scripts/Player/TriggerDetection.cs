using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer del personaje
    public Color waterColor = Color.blue;  // Color cuando el personaje está en agua
    private Color originalColor;  // Color original del Sprite

    private bool isInWater = false;  // Indica si el personaje está en agua
    private bool isInEarth = false;  // Indica si el personaje está en tierra

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        originalColor = spriteRenderer.color;  // Guarda el color original del Sprite
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
        UpdateSpriteColor();
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
        UpdateSpriteColor();
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
}
