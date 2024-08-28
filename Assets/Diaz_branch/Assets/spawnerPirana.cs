using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerPirana : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float radius = 8f;
    public float spawnInterval = 2f; // Intervalo de tiempo entre spawns en segundos
    public float duration; // Duraci�n total del spawning en segundos
    public float extraDistance = 2f; // Distancia extra fuera del radio

    void Start()
    {
        InvokeRepeating("Spawner", 1f, spawnInterval);
        Invoke("StopSpawning", duration); // Detener el spawning despu�s de 20 segundos
    }

    void Spawner()
    {
        // Generar un �ngulo aleatorio
        float angle = Random.Range(0f, Mathf.PI * 2);

        // Generar una distancia aleatoria fuera del radio
        float distance = Random.Range(radius, radius + extraDistance);

        // Calcular la posici�n basada en el �ngulo y la distancia
        Vector3 enemigoPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * distance;

        // Instanciar el enemigo en la posici�n calculada
        Instantiate(enemigoPrefab, enemigoPos, Quaternion.identity);
    }

    void StopSpawning()
    {
        CancelInvoke("Spawner");
    }
}
