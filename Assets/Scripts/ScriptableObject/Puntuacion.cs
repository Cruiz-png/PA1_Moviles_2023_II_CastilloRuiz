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
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Cargar el puntaje m�ximo al inicio
    }

    // M�todo para actualizar el puntaje m�ximo si el puntaje actual es mayor
    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore); // Guardar el nuevo puntaje m�ximo
            PlayerPrefs.Save();
        }
    }
}
