using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
   
    public GameObject enemigoPrefab;
    public int numeroDeEnemigos = 5;
    public float radius = 5f;
    public Transform player;

    void Start()
    {
        SpawnEnemigos();
    }

    void SpawnEnemigos()
    {
        for (int i = 0; i < numeroDeEnemigos; i++)
        {
            // Calcular el �ngulo para cada enemigo
            float angle = i * Mathf.PI * 4 / numeroDeEnemigos;
            // Calcular la posici�n basada en el �ngulo
            Vector3 enemigoPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            // A�adir la posici�n del jugador para que los enemigos lo rodeen
            enemigoPos += player.position;

            // Instanciar el enemigo
            Instantiate(enemigoPrefab, enemigoPos, Quaternion.identity);
        }
    }
}


