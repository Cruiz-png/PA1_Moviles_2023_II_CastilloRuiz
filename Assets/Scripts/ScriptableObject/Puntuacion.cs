using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPuntuacionData", menuName = "ScriptableObjects/Puntuacion")]
public class Puntuacion : ScriptableObject
{
    public float score;
    public List<float> highScoresList = new List<float>();

    public void Awake()
    {
        score = 0;
    }

    // Método para agregar el puntaje actual a la lista y ordenarla de mayor a menor
    public void UpdateHighScore()
    {
        // Agrega el puntaje actual a la lista
        highScoresList.Add(score);

        // Ordena la lista de mayor a menor
        highScoresList.Sort((a, b) => b.CompareTo(a));

        // Limita la lista a 10 elementos máximos
        if (highScoresList.Count > 10)
        {
            highScoresList.RemoveRange(10, highScoresList.Count - 10);
        }
    }
}
