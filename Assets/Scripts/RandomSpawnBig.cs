using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnBig : MonoBehaviour
{
    // Array de los CircleCollider2D donde se pueden generar los objetos
    public CircleCollider2D[] spawnPoints;
    // Prefab del objeto que se va a generar
    public GameObject objectToSpawn;
    // Tiempo en segundos antes de generar un nuevo objeto
    public float spawnInterval = 5f;

    // Referencia al objeto actualmente generado
    private GameObject currentSpawnedObject;

    void Start()
    {
        // Inicia la corrutina que verificará si puede generar un objeto
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        // Loop continuo para intentar generar un objeto
        while (true)
        {
            // Si no hay un objeto generado (el anterior fue destruido o desactivado)
            if (currentSpawnedObject == null)
            {
                // Espera el tiempo definido antes de generar un nuevo objeto
                yield return new WaitForSeconds(spawnInterval);

                // Genera un nuevo objeto en una posición aleatoria
                SpawnObjectAtRandomPoint();
            }

            // Espera un frame antes de continuar el loop
            yield return null;
        }
    }

    void SpawnObjectAtRandomPoint()
    {
        // Selecciona un índice aleatorio dentro del rango de los spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Obtiene la posición del centro del CircleCollider2D seleccionado
        Vector2 spawnPosition = spawnPoints[randomIndex].transform.position;

        // Instancia el objeto en la posición seleccionada y con la rotación por defecto
        currentSpawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
