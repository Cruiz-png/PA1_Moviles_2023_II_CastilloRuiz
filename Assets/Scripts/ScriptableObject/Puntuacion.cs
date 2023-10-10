using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPuntuacionData", menuName = "ScriptableObjects/Puntuacion")]
public class Puntuacion : ScriptableObject
{
    public float score;
    public float highScore;
    public List<Puntuacion> highScoresList = new List<Puntuacion>();

    public void Awake()
    {
        score = 0;
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    // M�todo para actualizar el puntaje m�ximo si el puntaje actual es mayor
    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();

            // Agrega el nuevo r�cord a la lista y ordena la lista de mayor a menor
            highScoresList.Add(new Puntuacion {score = highScore });
            highScoresList.Sort((a, b) => b.score.CompareTo(a.score));

            // Limita la lista a los 10 mejores r�cords
            if (highScoresList.Count > 10)
            {
                highScoresList.RemoveAt(highScoresList.Count - 1);
            }
        }
    }
}
