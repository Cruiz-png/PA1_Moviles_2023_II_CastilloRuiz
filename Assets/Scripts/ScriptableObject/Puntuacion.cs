using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPuntuacionData", menuName = "ScriptableObjects/Puntuacion")]
public class Puntuacion : ScriptableObject
{
    public float score;
    public float highScore;

    public void Awake()
    {
        score = 0;
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Cargar el puntaje máximo al inicio
    }

    // Método para actualizar el puntaje máximo si el puntaje actual es mayor
    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore); // Guardar el nuevo puntaje máximo
            PlayerPrefs.Save();
        }
    }
}
