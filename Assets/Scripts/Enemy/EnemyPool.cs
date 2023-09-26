using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que deseas instanciar
    public int poolSize = 10; // Tamaño del pool inicial

    private static List<GameObject> enemyPool; // Lista que almacena los enemigos en el pool

    private void Awake()
    {
        // Inicializa la lista del pool
        enemyPool = new List<GameObject>();

        // Llena el pool con objetos enemigos inactivos
        for (int i = 0; i < poolSize; i++)
        {
            // Instancia un enemigo a partir del prefab
            GameObject enemy = Instantiate(enemyPrefab);

            // Desactiva el enemigo para que no sea visible ni interactivo
            enemy.SetActive(false);

            // Agrega el enemigo a la lista del pool
            enemyPool.Add(enemy);
        }
    }

    // Método para obtener un enemigo del pool
    public static GameObject GetEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            // Busca un enemigo que esté inactivo en el pool
            if (!enemy.activeInHierarchy)
            {
                // Activa el enemigo y lo devuelve
                enemy.SetActive(true);
                return enemy;
            }
        }

        // Si no hay enemigos inactivos en el pool, retorna null
        return null;
    }

    // Método para devolver un enemigo al pool
    public static void ReturnEnemyToPool(GameObject enemy)
    {
        // Desactiva el enemigo para ocultarlo y marcarlo como inactivo en el pool
        enemy.SetActive(false);
    }
}
