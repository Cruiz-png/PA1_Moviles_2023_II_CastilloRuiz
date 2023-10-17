using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultadosManager : MonoBehaviour
{
    public Puntuacion puntuacion;
    public Text highScoresText;

    private void Start()
    {
        puntuacion.UpdateHighScore();
    }

    private void Update()
    {
        string highScoresString = "PUNTAJES REGISTRADOS:\n";

        int maxPuntajesAMostrar = 10;

        for (int i = 0; i < maxPuntajesAMostrar; i++)
        {
            if (i < puntuacion.highScoresList.Count)
            {
                highScoresString += "Puntaje " + (i + 1) + ": " + Mathf.RoundToInt(puntuacion.highScoresList[i]) + "\n";
            }
            else
            {
                highScoresString += "Puntaje " + (i + 1) + ": 0\n";
            }
        }

        highScoresText.text = highScoresString;
    }
}
