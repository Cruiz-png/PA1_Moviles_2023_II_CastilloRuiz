using System.Collections;
using UnityEngine;

public class MonedaSpawn : MonoBehaviour
{
    public float spawnInterval = 2f; // Intervalo de generación en segundos
    private Coroutine spawnCoroutine;

    private void Start()
    {
        // Comienza a generar basura a intervalos regulares
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private void OnDestroy()
    {
        // Detiene la generación de basuras cuando el objeto se destruye
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Obtén un basura del pool
            GameObject moneda = FiguraMonedaPool.GetMoneda();
            if (moneda != null)
            {
                // Establece la posición de inicio dentro del rango especificado en el eje Y
                float randomY = Random.Range(-2f, 2f);
                moneda.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);

                // Activa el basura
                moneda.SetActive(true);
            }

            // Espera el intervalo de generación antes de crear otro basura
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
