using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    public void Start()
    {
        gameObject.SetActive(true);
    }

    public Puntuacion puntuacion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Inicia el proceso de reaparición cuando colisiona con el jugador
            puntuacion.score += 10;
            gameObject.SetActive(false);
        }
    }
}
