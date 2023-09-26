using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguraMonedas : MonoBehaviour
{
    private Vector3 initialPosition; // Guarda la posici�n inicial del enemigo
    public float movementSpeed = 5f; // Velocidad de movimiento hacia la izquierda
    public float leftLimit = -13f; // L�mite izquierdo donde el enemigo se devuelve al pool
    public float respawnTime = 5f; // Tiempo en segundos para reaparecer despu�s de colisionar

    public GameObject[] monedas;
    private Rigidbody2D rb;
    private bool isRespawning = false;
    private float respawnTimer = 0f;
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
        rb.velocity = new Vector2(-movementSpeed, 0f);
        // Verifica si el enemigo ha alcanzado el l�mite izquierdo
        if (transform.position.x <= leftLimit)
        {
            // Devuelve el enemigo al pool
            FiguraMonedaPool.ReturnMonedaToPool(gameObject);
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
}
