using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnInterval = 2f; // Intervalo de generación en segundos

    private Coroutine spawnCoroutine;

    private void Start()
    {
        // Comienza a generar objetos a intervalos regulares
        spawnCoroutine = StartCoroutine(SpawnObjects());
    }

    private void OnDestroy()
    {
        // Detiene la generación cuando el objeto se destruye
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Genera aleatoriamente entre monedas y enemigos
            if (Random.Range(0f, 1f) < 0.5f)
            {
                // Generar una moneda desde MonedaPool
                GameObject moneda = FiguraMonedaPool.GetMoneda();
                if (moneda != null)
                {
                    // Establece la posición de inicio dentro del rango especificado en el eje Y
                    float randomY = Random.Range(-2f, 2f);
                    moneda.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);

                    // Activa la moneda
                    moneda.SetActive(true);
                }
            }
            else
            {
                // Generar un enemigo desde EnemigoPool
                GameObject enemigo = EnemyPool.GetEnemy();
                if (enemigo != null)
                {
                    // Establece la posición de inicio dentro del rango especificado en el eje Y
                    float randomY = Random.Range(-2f, 2f);
                    enemigo.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);

                    // Activa el enemigo
                    enemigo.SetActive(true);
                }
            }

            // Espera el intervalo de generación antes de crear otro objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
