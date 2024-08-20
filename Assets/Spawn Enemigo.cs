using System.Collections;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public GameObject[] enemigosPrefabs; // Array de diferentes prefabs de enemigos
    public int cantidadEnemigosTipo1 = 5; // Cantidad de enemigos tipo 1
    public int cantidadEnemigosTipo2 = 2; // Cantidad de enemigos tipo 2
    public float radioMin = 10f;
    public float radioMax = 18f;
    public Transform player;
    public int numeroDeOleadas = 3;
    public float tiempoEntreOleadas = 10f;

    void Start()
    {
        StartCoroutine(SpawnOleadas());
    }

    IEnumerator SpawnOleadas()
    {
        for (int oleada = 1; oleada <= numeroDeOleadas; oleada++)
        {
            Debug.Log("Comenzando oleada " + oleada);
            SpawnEnemigos();
            yield return new WaitForSeconds(tiempoEntreOleadas);
        }
    }

    void SpawnEnemigos()
    {
        // Instanciar enemigos tipo 1
        for (int i = 0; i < cantidadEnemigosTipo1; i++)
        {
            SpawnEnemigoTipo(0); // Instancia el primer tipo de enemigo
        }

        // Instanciar enemigos tipo 2
        for (int i = 0; i < cantidadEnemigosTipo2; i++)
        {
            SpawnEnemigoTipo(1); // Instancia el segundo tipo de enemigo
        }
    }

    void SpawnEnemigoTipo(int tipo)
    {
        // Calcular un ángulo aleatorio
        float angle = Random.Range(0f, Mathf.PI * 2);
        // Calcular una distancia aleatoria dentro del rango
        float distancia = Random.Range(radioMin, radioMax);
        // Calcular la posición basada en el ángulo y la distancia
        Vector3 enemigoPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * distancia;
        // Añadir la posición del jugador para que los enemigos lo rodeen
        enemigoPos += player.position;

        // Seleccionar el tipo de enemigo basado en el índice
        if (tipo >= 0 && tipo < enemigosPrefabs.Length)
        {
            GameObject enemigoPrefab = enemigosPrefabs[tipo];
            // Instanciar el enemigo seleccionado
            Instantiate(enemigoPrefab, enemigoPos, Quaternion.identity);
        }
    }
}
