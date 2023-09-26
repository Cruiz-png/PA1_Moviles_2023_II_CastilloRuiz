using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    public Puntuacion puntuacion;
    private Vector3 initialPosition; // Guarda la posición inicial del enemigo
    public float movementSpeed = 5f; // Velocidad de movimiento hacia la izquierda
    public float leftLimit = -13f; // Límite izquierdo donde el enemigo se devuelve al pool
    public float respawnTime = 5f; // Tiempo en segundos para reaparecer después de colisionar

    private Rigidbody2D rb;
    private bool isRespawning = false;
    private float respawnTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Guarda la posición inicial del enemigo al inicio
        initialPosition = transform.position;

        // Activa el enemigo al comienzo
        gameObject.SetActive(true);
    }

    private void Update()
    {
        rb.velocity = new Vector2(-movementSpeed, 0f);
        // Verifica si el enemigo ha alcanzado el límite izquierdo
        if (transform.position.x <= leftLimit)
        {
            // Devuelve el enemigo al pool
            MonedaPool.ReturnMonedaToPool(gameObject);
        }

        // Si está en proceso de reaparecer, cuenta el tiempo
        if (isRespawning)
        {
            respawnTimer += Time.deltaTime;

            // Si ha pasado el tiempo de respawn, restablece la posición
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
            // Inicia el proceso de reaparición cuando colisiona con el jugador
            puntuacion.score += 10;
            gameObject.SetActive(false);
            isRespawning = true;
        }
    }
}
