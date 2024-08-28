using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private bool shouldMove = true;

    void Update()
    {
        if (target != null && shouldMove)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detectado con: " + other.name); // Para ver si algo está siendo detectado
        if (other.CompareTag("Player"))
        {
            Debug.Log("Golpe");
            shouldMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldMove = true;
        }
    }

}
