using System.Collections;
using UnityEngine;

public class EnemySpawner:MonoBehaviour
{
    public float spawnInterval = 2f; // Intervalo de generaci�n en segundos
    private Coroutine spawnCoroutine;

    private void Start()
    {
        // Comienza a generar enemigos a intervalos regulares
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private void OnDestroy()
    {
        // Detiene la generaci�n de enemigos cuando el objeto se destruye
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Obt�n un enemigo del pool
            GameObject enemy = EnemyPool.GetEnemy();
            if (enemy != null)
            {
                // Establece la posici�n de inicio dentro del rango especificado en el eje Y
                float randomY = Random.Range(-3.8f, 3.8f);
                enemy.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);

                // Activa el enemigo
                enemy.SetActive(true);
            }

            // Espera el intervalo de generaci�n antes de crear otro enemigo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
