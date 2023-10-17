using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Vector3 initialPosition; // Guarda la posici�n inicial del enemigo
    public float movementSpeed = 5f; // Velocidad de movimiento hacia la izquierda
    public float leftLimit = -13f; // L�mite izquierdo donde el enemigo se devuelve al pool
    public float respawnTime = 5f; // Tiempo en segundos para reaparecer despu�s de colisionar
    public float velocidadRotation = 180f;
    private Rigidbody2D rb;
    private bool isRespawning = false;
    private float respawnTimer = 0f;
    public Text messagePanel; // Asigna un GameObject con un componente Text para mostrar el mensaje


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        // Guarda la posici�n inicial del enemigo al inicio
        initialPosition = transform.position;

        // Activa el enemigo al comienzo
        gameObject.SetActive(true);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * velocidadRotation * Time.deltaTime);
        rb.velocity = new Vector2(-movementSpeed, 0f);
        // Verifica si el enemigo ha alcanzado el l�mite izquierdo
        if (transform.position.x <= leftLimit)
        {
            // Devuelve el enemigo al pool
            EnemyPool.ReturnEnemyToPool(gameObject);
        }

        // Si est� en proceso de reaparecer, cuenta el tiempo
        if (isRespawning)
        {
            respawnTimer += Time.deltaTime;

            // Si ha pasado el tiempo de respawn, restablece la posici�n
            if (respawnTimer >= respawnTime)
            {
                isRespawning = false;
                respawnTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Detiene todo en la escena
            Time.timeScale = 0f;

            // Espera 2 segundos antes de cargar la escena "Resultados"
            StartCoroutine(WaitAndLoadResultsScene(2f));
        }
    }

    private IEnumerator WaitAndLoadResultsScene(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        // Carga la escena "Resultados"
        SceneGlobalManager.Instance.LoadSceneAsync("Resultados", LoadSceneMode.Additive);

        Time.timeScale = 0f;
    }
}
